using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a service specifiec metadata for the specified consumer request.
    /// </summary>
    public interface IMetadataProvider
    {
        /// <summary>
        /// Determines whether this provider can handle the specified request.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns><c>true</c> if this provider can handle <paramref name="request"/>; otherwise <c>false</c>.</returns>
        bool CanHandle(ConsumerRequest request);

        /// <summary>
        /// Returns a <see cref="Metadata"/> that represents the specified URL.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>The <see cref="Metadata"/> if this provider can handle <paramref name="request"/>; otherwise <c>null</c>.</returns>
        Metadata GetMetadata(ConsumerRequest request);
    }
}