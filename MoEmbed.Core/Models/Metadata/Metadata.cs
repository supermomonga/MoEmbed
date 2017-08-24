using System.Threading.Tasks;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents a metadata for the specified URL.
    /// </summary>
    /// <remarks>
    /// Derived types must be XAML serializable.
    /// </remarks>
    public abstract class Metadata
    {
        /// <summary>
        /// Asynchronously returns embed data from remote service.
        /// </summary>
        /// <param name="context">The context of the request.</param>
        /// <returns>A task that represents the asynchronous fetch operation.</returns>
        public abstract Task<EmbedData> FetchAsync(RequestContext context);

        /// <summary>
        /// Invoked when the instance deserialized from storage.
        /// </summary>
        /// <param name="service">The service that deserialized metadata.</param>
        public virtual void OnDeserialized(MetadataService service)
        {
        }
    }
}