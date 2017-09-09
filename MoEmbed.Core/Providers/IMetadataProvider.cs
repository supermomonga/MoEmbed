using System.Collections.Generic;
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
        /// Gets a value indicating whether the provider can handle  any host.
        /// </summary>
        bool SupportsAnyHost { get; }

        /// <summary>
        /// Gets a value indicating wheter the provider is enabled.
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        IEnumerable<string> GetSupportedHostNames();

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