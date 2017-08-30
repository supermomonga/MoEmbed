using System;
using System.Threading.Tasks;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the <see href="imgur.com"/>.
    /// </summary>
    [Serializable]
    public class ImgurMetadata : UnknownMetadata
    {
        /// <inheritdoc />
        protected override async Task<EmbedData> FetchAsyncCore(RequestContext context)
        {
            var Data = await base.FetchAsyncCore(context);
            Data.Type = EmbedDataTypes.SingleImage;
            Data.Medias.Add(Data.MetadataImage);
            return Data;
        }
    }
}