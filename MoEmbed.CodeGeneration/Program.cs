using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

var repoRoot = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(GetScriptPath()), ".."));

var skip = new HashSet<string>() {
    "gyazo",
    "nanoo" // It conflicts with zhdk.ch.
};
var nameMap = new Dictionary<string, string>()
{
    ["23hq"] = "TwentyThree",
    ["3q"] = "ThreeQ"
};

// --- Phase 1: Parse all provider YAML files ---

var providers = new List<ProviderInfo>();
var d = Path.GetFullPath(Path.Combine(repoRoot, "oembed/providers"));

foreach (var f in Directory.GetFiles(d, "*.yml"))
{
    var rawName = Path.GetFileNameWithoutExtension(f);
    if (skip.Contains(rawName))
    {
        continue;
    }
    string className;
    if (nameMap.ContainsKey(rawName))
    {
        className = nameMap[rawName];
    }
    else
    {
        className = string.Concat(rawName.Split('_', '.', '-').Select(s => s.Substring(0, 1).ToUpper() + s.Substring(1)));
    }

    var schemes = false;
    string prov = null;
    string url = null;
    var schemeUrls = new List<string>();

    using (var sr = new StreamReader(f))
    {
        for (var l = sr.ReadLine(); l != null; l = sr.ReadLine())
        {
            if (schemes)
            {
                var um = Regex.Match(l, "\\s+- ");
                if (um.Success)
                {
                    var u = l.Substring(um.Length).Trim('\'', ',', '"', ' ');
                    schemeUrls.Add(string.Join(".*", u.Split(new[] { '*' }, StringSplitOptions.RemoveEmptyEntries).Select(Regex.Escape)));
                    continue;
                }
                schemes = false;
            }

            var pm = Regex.Match(l, "  provider_url: ");
            if (pm.Success)
            {
                prov = l.Substring(pm.Length).Trim('\'', '"', ' ');
                continue;
            }

            if (Regex.IsMatch(l, "  - schemes:"))
            {
                schemes = true;
                continue;
            }
            var em = Regex.Match(l, @"^\s+-?\s+url:\s*");
            if (em.Success)
            {
                url = l.Substring(em.Length).Trim('\'', '"', ' ');
                continue;
            }
        }
    }

    var candidateHostNames = (schemeUrls.Any() ? schemeUrls : Enumerable.Repeat(prov ?? "", 1))
                        .Select(u =>
                        {
                            var m = Regex.Match(u, "^https?://([^/]+)(/|$)");
                            return m.Groups[1].Value.Replace("\\", "").TrimStart('*', '.');
                        })
                        .SelectMany(hn =>
                        {
                            var cps = hn.Split('.');
                            var r = new List<string>();
                            for (var i = 0; i < cps.Length - 1; i++)
                            {
                                var cp = cps[i];
                                if (!Regex.IsMatch(cp, "^(com?|net?|org?|ac|gov?|lg)$"))
                                {
                                    r.Add(string.Join(".", cps.Skip(i)));
                                }
                            }
                            return r;
                        })
                        .Distinct()
                        .ToList();

    providers.Add(new ProviderInfo
    {
        FileName = Path.GetFileName(f),
        RawName = rawName,
        ClassName = className,
        ProviderUrl = prov,
        EndpointUrl = url,
        SchemeUrls = schemeUrls,
        CandidateHostNames = candidateHostNames
    });
}

// --- Phase 2: Resolve host name conflicts using name similarity ---

var resolved = MoEmbed.CodeGeneration.HostNameResolver.Resolve(
    providers.Select(p => new MoEmbed.CodeGeneration.ProviderHostEntry
    {
        ProviderName = p.RawName,
        CandidateHostNames = p.CandidateHostNames
    }));

foreach (var p in providers)
{
    p.ResolvedHostNames = resolved[p.RawName];
}

// --- Phase 3: Generate code ---

using (var sw = new StreamWriter(Path.Combine(repoRoot, "MoEmbed.Core/Providers/Generated Codes/OEmbedProxyMetadataProviders.cs")))
{
    sw.WriteLine("using System;");
    sw.WriteLine("using System.Collections.Generic;");
    sw.WriteLine("using System.Linq;");
    sw.WriteLine("using System.Text.RegularExpressions;");
    sw.WriteLine("using MoEmbed.Models;");
    sw.WriteLine("namespace MoEmbed.Providers");
    sw.WriteLine("{");

    var generated = new List<string>();

    foreach (var p in providers)
    {
        if (string.IsNullOrWhiteSpace(p.EndpointUrl) || string.IsNullOrWhiteSpace(p.ProviderUrl))
        {
            sw.WriteLine($"    // TODO: {p.FileName} Error: No Endpoint URL");
            continue;
        }
        generated.Add(p.ClassName);

        sw.WriteLine(@"    /// <summary>");
        sw.WriteLine($"    /// Handles oEmbed request for <see href=\"{p.ProviderUrl}\" />.");
        sw.WriteLine(@"    /// </summary>");
        sw.WriteLine($"    public sealed partial class {p.ClassName}MetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider");
        sw.WriteLine(@"    {");

        var urlPattern = p.SchemeUrls.Count > 2 ? ("(" + string.Join("|", p.SchemeUrls) + ")")
                        : p.SchemeUrls.Any() ? p.SchemeUrls[0]
                        : Regex.Escape(p.ProviderUrl);

        sw.WriteLine($"        private static readonly Regex _UriPattern = new Regex(@\"^{urlPattern}\");");
        sw.WriteLine();

        sw.WriteLine("        /// <inheritdoc />");
        sw.WriteLine("        public override IEnumerable<string> GetSupportedHostNames()");
        sw.WriteLine("        {");
        foreach (var hn in p.ResolvedHostNames)
        {
            sw.WriteLine($"            yield return \"{hn}\";");
        }
        sw.WriteLine("        }");
        sw.WriteLine();

        sw.WriteLine("        /// <inheritdoc />");
        sw.WriteLine("        public override bool CanHandle(Uri uri)");
        sw.WriteLine("            => _UriPattern.IsMatch(uri.ToString());");
        sw.WriteLine();

        sw.WriteLine("        /// <inheritdoc />");
        sw.WriteLine("        protected override Uri GetProviderUriFor(ConsumerRequest request)");
        if (p.EndpointUrl.EndsWith(".xml") || p.EndpointUrl.EndsWith(".json"))
        {
            sw.WriteLine($"            => GetProviderUriWithoutFormat(\"{p.EndpointUrl}\", request);");
        }
        else if (p.EndpointUrl.EndsWith(".{format}"))
        {
            sw.WriteLine($"            => GetProviderUriWithExtension(\"{p.EndpointUrl.Substring(0, p.EndpointUrl.Length - 9)}\", request);");
        }
        else
        {
            sw.WriteLine($"            => GetProviderUriCore(\"{p.EndpointUrl.Split('?')[0]}\", request);");
        }
        sw.WriteLine(@"    }");
        sw.WriteLine();
    }
    sw.WriteLine(@"    partial class OEmbedProxyMetadataProvider");
    sw.WriteLine(@"    {");
    sw.WriteLine(@"        internal static IEnumerable<Type> CreateKnownHandlerTypes()");
    sw.WriteLine(@"        {");
    foreach (var n in generated)
    {
        sw.WriteLine($"            yield return typeof({n}MetadataProvider);");
    }

    sw.WriteLine(@"        }");
    sw.WriteLine(@"    }");
    sw.WriteLine(@"}");
}

static string GetScriptPath([CallerFilePath] string path = "") => path;

class ProviderInfo
{
    public string FileName;
    public string RawName;
    public string ClassName;
    public string ProviderUrl;
    public string EndpointUrl;
    public List<string> SchemeUrls;
    public List<string> CandidateHostNames;
    public List<string> ResolvedHostNames;
}
