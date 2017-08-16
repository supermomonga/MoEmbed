using System.IO;
using System.Threading.Tasks;
using MoEmbed.Models.OEmbed;

namespace MoEmbed.Models.Metadata
{
    // TODO: Move to Another file
    public enum Types { Photo, Video, Link, Rich }

    public abstract class Metadata
    {
        public abstract Task<IEmbedData> FetchAsync();

        /// <summary>
        /// Invoked when the instance deserialized from storage.
        /// </summary>
        /// <param name="service">The service that deserialized metadata.</param>
        public virtual void OnDeserialized(MetadataService service)
        {
        }
    }
}

