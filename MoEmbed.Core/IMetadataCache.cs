using MoEmbed.Models;

namespace MoEmbed
{
    /// <summary>
    /// Provides cache storage to <see cref="MetadataService" />.
    /// </summary>
    public interface IMetadataCache
    {
        /// <summary>
        /// Reads the cached <see cref="Metadata" /> for the URL of <paramref name="request"/>.
        /// </summary>
        /// <param name="service">The <see cref="MetadataService" /> reading cache.</param>
        /// <param name="request">The consumer request.</param>
        /// <returns>If hit, a cached <see cref="Metadata"/>. Otherwise <c>null</c>.</returns>
        Metadata Read(MetadataService service, ConsumerRequest request);

        void Write(MetadataService service, ConsumerRequest request, Metadata metadata);
    }
}