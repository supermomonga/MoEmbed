using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public class ImgurMetadataProvider : UnknownMetadataProvider
    {
        bool SupportsAnyHost
            => false;

        private static readonly Regex regex = new Regex(@"^https?://imgur\.com/([a-zA-Z0-9)+$");

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public new IEnumerable<string> GetSupportedHostNames()
            => new[] { "imgur.com" };

        public new bool CanHandle(ConsumerRequest request)
            => regex.IsMatch(request.Url.ToString());

        public new Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }
            return new ImgurMetadata()
            {
                Uri = request.Url.ToString(),
            };
        }
    }
}
