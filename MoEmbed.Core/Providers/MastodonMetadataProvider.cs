using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using MoEmbed.Models;
using MoEmbed.Models.Mastodon;
using MoEmbed.Models.Metadata;
using Newtonsoft.Json;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Represents options of the <see cref="MastodonMetadataProvider" />.
    /// </summary>
    public sealed class MastodonMetadataOptions
    {
        /// <summary>
        /// Gets or sets a secret token for the Mastodon instances API.
        /// </summary>
        public string MastodonInstancesSecretToken { get; set; }
    }

    /// <summary>
    /// Provides a mastodon specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed class MastodonMetadataProvider : IMetadataProvider
    {
        // TODO: fetch from instance list
        private static HashSet<string> _Hosts;

        private static HashSet<string> Hosts
        {
            get
            {
                if (_Hosts == null)
                {
                    if (InstancesSecretToken != null)
                    {
                        try
                        {
                            using (var hc = new HttpClient())
                            {
                                var req = new HttpRequestMessage(HttpMethod.Get, "https://instances.social/api/1.0/instances/list?count=0&include_dead=false");
                                req.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", InstancesSecretToken);

                                var res = hc.SendAsync(req).ConfigureAwait(false).GetAwaiter().GetResult();

                                if (res.IsSuccessStatusCode)
                                {
                                    using (var s = res.Content.ReadAsStreamAsync().ConfigureAwait(false).GetAwaiter().GetResult())
                                    using (var sr = new StreamReader(s))
                                    using (var jr = new JsonTextReader(sr))
                                    {
                                        var ir = new JsonSerializer().Deserialize<InstancesResponse>(jr);
                                        _Hosts = new HashSet<string>(ir.Instances.Select(h => h.Name));
                                    }
                                }
                            }
                        }
                        catch
                        { }
                    }
                    if (_Hosts == null)
                    {
                        _Hosts = new HashSet<string> { "pawoo.net", "mstdn.jp", "friends.nico" };
                    }
                }
                return _Hosts;
            }
        }

        private static readonly Regex _PathPattern = new Regex(@"^/@[^/]+/([0-9]+)$");

        /// <summary>
        /// Gets or sets a secret token for the Mastodon instances API.
        /// </summary>
        public static string InstancesSecretToken { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MastodonMetadataProvider" /> with the
        /// configuration for imgur.
        /// </summary>
        /// <param name="optionsAccessor">The accessor to the configuration for imgur.</param>
        public MastodonMetadataProvider(IOptions<MastodonMetadataOptions> optionsAccessor)
        {
            var token = optionsAccessor?.Value?.MastodonInstancesSecretToken
                    ?? Environment.GetEnvironmentVariable("MASTODON_INSTANCES_SECRET_TOKEN");

            InstancesSecretToken = token ?? InstancesSecretToken;
        }

        bool IMetadataProvider.SupportsAnyHost => false;

        bool IMetadataProvider.IsEnabled => true;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
            => Hosts;

        /// <summary>
        /// Determines whether this provider can handle the specified request.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// <c>true</c> if this provider can handle <paramref name="request" />; otherwise <c>false</c>.
        /// </returns>
        public bool CanHandle(ConsumerRequest request)
        {
            var u = request.Url;

            return u.IsDefaultPort
                && u.Scheme == "https"
                && Hosts.Contains(u.Host)
                && _PathPattern.IsMatch(u.AbsolutePath);
        }

        /// <summary>
        /// Returns a <see cref="Metadata" /> that represents the specified URL.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// The <see cref="NicovideoMetadata" /> if this provider can handle <paramref name="request"
        /// />; otherwise <c>null</c>.
        /// </returns>
        public Metadata GetMetadata(ConsumerRequest request)
        {
            var u = request.Url;

            if (u.IsDefaultPort
                && u.Scheme == "https"
                && Hosts.Contains(u.Host))
            {
                var m = _PathPattern.Match(u.AbsolutePath);

                if (m.Success
                    && long.TryParse(m.Groups[1].Value, out var l))
                {
                    return new MastodonMetadata()
                    {
                        Host = u.Host,
                        StatusId = l
                    };
                }
            }

            return null;
        }
    }
}