using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

var dir = Path.GetDirectoryName(Path.GetFullPath("a"));

using (var sw = new StreamWriter(Path.Combine(dir, "../MoEmbed.Core/Providers/Generated Codes/OEmbedProxyMetadataProviders.cs")))
{
  sw.WriteLine("using System;");
  sw.WriteLine("using System.Collections.Generic;");
  sw.WriteLine("using System.Linq;");
  sw.WriteLine("using System.Text.RegularExpressions;");
  sw.WriteLine("using MoEmbed.Models;");
  sw.WriteLine("namespace MoEmbed.Providers");
  sw.WriteLine("{");

  var skip = new HashSet<string>() { "twitter", "gyazo" };
  var nameMap = new Dictionary<string, string>()
  {
    ["23hq"] = "TwentyThree"
  };
  var schemeUrls = new List<string>();
  var generated = new List<string>();
  var d = Path.Combine(dir, "../oembed/providers");

  foreach (var f in Directory.GetFiles(d, "*.yml"))
  {
    var n = Path.GetFileNameWithoutExtension(f);
    if (skip.Contains(n))
    {
      continue;
    }
    if (nameMap.ContainsKey(n))
    {
      n = nameMap[n];
    }
    else
    {
      n = string.Concat(n.Split('_', '.', '-').Select(s => s.Substring(0, 1).ToUpper() + s.Substring(1)));
    }
    var schemes = false;
    string prov = null;
    string url = null;
    schemeUrls.Clear();

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

    if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(prov))
    {
      sw.WriteLine($"    // TODO: {Path.GetFileName(f)} Error: No Endpoint URL");
      continue;
    }
    generated.Add(n);

    sw.WriteLine(@"    /// <summary>");
    sw.WriteLine($"    /// Handles oEmbed request for <see href=\"{prov}\" />.");
    sw.WriteLine(@"    /// </summary>");
    sw.WriteLine($"    public sealed partial class {n}MetadataProvider : OEmbedProxyMetadataProvider, IMetadataProvider");
    sw.WriteLine(@"    {");

    var urlPattern = schemeUrls.Count > 2 ? ("(" + string.Join("|", schemeUrls) + ")")
                    : schemeUrls.Any() ? schemeUrls[0]
                    : Regex.Escape(prov);

    sw.WriteLine($"        private static readonly Regex _UriPattern = new Regex(@\"^{urlPattern}\");");
    sw.WriteLine();

    var hostNames = (schemeUrls.Any() ? schemeUrls : Enumerable.Repeat(prov, 1))
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
                        .ToArray();

    sw.WriteLine("        /// <inheritdoc />");
    sw.WriteLine("        public override IEnumerable<string> GetSupportedHostNames()");
    sw.WriteLine("        {");
    foreach (var hn in hostNames)
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
    if (url.EndsWith(".xml") || url.EndsWith(".json"))
    {
      sw.WriteLine($"            => GetProviderUriWithoutFormat(\"{url}\", request);");
    }
    else if (url.EndsWith(".{format}"))
    {
      sw.WriteLine($"            => GetProviderUriWithExtension(\"{url.Substring(0, url.Length - 9)}\", request);");
    }
    else
    {
      sw.WriteLine($"            => GetProviderUriCore(\"{url.Split('?')[0]}\", request);");
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