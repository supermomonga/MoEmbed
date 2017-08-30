using System.Collections.Generic;
using System.Text.RegularExpressions;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Handles metadata requests for the <see href="https://droplr.com" />.
    /// </summary>
    public sealed class DroplrMetadataProvider : IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https?://d.pr/i/(?<hash>[A-Za-z0-9]+)(\.(jpg|png|gif|mp4|mp3))?");

        bool IMetadataProvider.SupportsAnyHost
            => false;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
        {
            yield return "d.pr";
        }

        /// <summary>
        /// Determines whether this provider can handle the specified request.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns><c>true</c> if this provider can handle <paramref name="request"/>; otherwise <c>false</c>.</returns>
        public bool CanHandle(ConsumerRequest request)
            => _UriPattern.IsMatch(request.Url.ToString());

        /// <summary>
        /// Returns a <see cref="Metadata"/> that represents the specified URL.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>The <see cref="OEmbedProxyMetadata"/> if this provider can handle <paramref name="request"/>; otherwise <c>null</c>.</returns>
        public Metadata GetMetadata(ConsumerRequest request)
        {
            var m = _UriPattern.Match(request.Url.ToString());
            if (m.Success)
            {
                var url = "https://d.pr/i/" + m.Groups["hash"].Value;
                return new DroplrMetadata()
                {
                    Uri = url,
                };
            }
            return null;
        }
    }
}