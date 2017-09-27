using System.Collections.Generic;
using System.Text.RegularExpressions;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a mastodon specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed class MastodonMetadataProvider : IMetadataProvider
    {
        // TODO: fetch from instance list
        private static HashSet<string> _Hosts = new HashSet<string> { "pawoo.net", "mstdn.jp", "friends.nico" };

        private static HashSet<string> Hosts => _Hosts;

        private static readonly Regex _PathPattern = new Regex(@"^/@[^/]+/([0-9]+)$");

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