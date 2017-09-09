using System.Collections.Generic;
using System.Text.RegularExpressions;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a nicovido.jp specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed class NicovideoMetadataProvider : IMetadataProvider
    {
        private static readonly Regex regex = new Regex(@"^http://www.nicovideo.jp/watch/sm([0-9]+)");

        bool IMetadataProvider.SupportsAnyHost
            => false;

        bool IMetadataProvider.IsEnabled
            => true;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
            => new[] { "nicovideo.jp", "www.nicovideo.jp" };

        /// <summary>
        /// Determines whether this provider can handle the specified request.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// <c>true</c> if this provider can handle <paramref name="request" />; otherwise <c>false</c>.
        /// </returns>
        public bool CanHandle(ConsumerRequest request)
            => regex.IsMatch(request.Url.ToString());

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
            var m = regex.Match(request.Url.ToString());
            if (m.Success)
            {
                return new NicovideoMetadata()
                {
                    VideoId = long.Parse(m.Groups[1].Value)
                };
            }
            return null;
        }
    }
}