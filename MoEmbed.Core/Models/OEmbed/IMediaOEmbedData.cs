using System.Collections.Generic;

namespace MoEmbed.Models.OEmbed
{
    public interface IMediaOEmbedData : IOEmbedData
    {
        /// <summary>
        /// Gets media list.
        /// </summary>
        IReadOnlyList<Media> Medias { get; }
    }
}
