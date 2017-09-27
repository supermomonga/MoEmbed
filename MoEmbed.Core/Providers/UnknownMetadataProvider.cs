using System.Collections.Generic;
using System.Linq;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides metadata to any URL.
    /// </summary>
    public sealed class UnknownMetadataProvider : IMetadataProvider
    {
        bool IMetadataProvider.SupportsAnyHost
            => true;

        bool IMetadataProvider.IsEnabled
            => true;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
            => Enumerable.Empty<string>();

        /// <summary>
        /// Determines whether this provider can handle the specified request.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// <c>true</c> if this provider can handle <paramref name="request" />; otherwise <c>false</c>.
        /// </returns>
        public bool CanHandle(ConsumerRequest request)
            => request.Url.Scheme == "http" || request.Url.Scheme == "https";

        /// <summary>
        /// Returns a <see cref="Metadata" /> that represents the specified URL.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// The <see cref="Metadata" /> if this provider can handle <paramref name="request" />;
        /// otherwise <c>null</c>.
        /// </returns>
        public Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }
            return new UnknownMetadata()
            {
                Url = request.Url,
            };
        }
    }
}