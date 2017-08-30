using System.Collections.Generic;
using System.Text.RegularExpressions;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a nicovido.jp specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed class PixivMetadataProvider : IMetadataProvider
    {
        private static readonly Regex _UriPattern = new Regex(@"^https?://www.pixiv.net/.+illust_id=(?<illust_id>[0-9]+)(&.+)?$");

        bool IMetadataProvider.SupportsAnyHost
            => false;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
            => new[] { "pixiv.net", "www.pixiv.net" };

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
        /// <returns>The <see cref="PixivMetadata"/> if this provider can handle <paramref name="request"/>; otherwise <c>null</c>.</returns>
        public Metadata GetMetadata(ConsumerRequest request)
        {
            var m = _UriPattern.Match(request.Url.ToString());
            if (m.Success)
            {
                var illustId = int.Parse(m.Groups["illust_id"].Value);
                return new PixivMetadata()
                {
                    Url = $"https://www.pixiv.net/member_illust.php?mode=medium&illust_id={ illustId }".ToUri(),
                    IllustId = illustId
                };
            }
            return null;
        }
    }
}