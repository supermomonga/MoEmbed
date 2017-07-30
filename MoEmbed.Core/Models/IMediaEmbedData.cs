using System.Collections.Generic;

namespace MoEmbed.Models
{
    public interface IMediaEmbedData : IEmbedData
    {
        /// <summary>
        /// Gets media list.
        /// </summary>
        IReadOnlyList<Media> Medias { get; }
    }
}