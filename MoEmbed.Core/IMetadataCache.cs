using System.Threading.Tasks;
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
        /// <returns>The task object representing the asynchronous operation.
        /// The <see cref="Task{TResult}.Result"/> property on the task object returns a cached <see cref="Metadata"/>.</returns>
        Task<Metadata> ReadAsync(MetadataService service, ConsumerRequest request);

        Task WriteAsync(MetadataService service, ConsumerRequest request, Metadata metadata);
    }
}