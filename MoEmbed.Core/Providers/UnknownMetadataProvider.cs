using System.Collections.Generic;
using System.Linq;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public class UnknownMetadataProvider : IMetadataProvider
    {
        bool IMetadataProvider.SupportsAnyHost
            => true;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
            => Enumerable.Empty<string>();

        public bool CanHandle(ConsumerRequest request)
            => request.Url.Scheme == "http" || request.Url.Scheme == "https";

        public Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }
            return new UnknownMetadata()
            {
                Uri = request.Url.ToString(),
            };
        }
    }
}