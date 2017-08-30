using System;
using System.Threading.Tasks;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the unknown URL.
    /// </summary>
    [Serializable]
    public class DroplrMetadata : UnknownMetadata
    {
        public DroplrMetadata()
        {
        }

        public DroplrMetadata(string uri)
        {
            Uri = uri;
        }

        public DroplrMetadata(Uri uri)
        {
            Uri = uri.ToString();
        }

        protected override async Task<EmbedData> FetchAsyncCore(RequestContext context)
        {
            var Data = await base.FetchAsyncCore(context);
            Data.Type = EmbedDataTypes.SingleImage;
            Data.Medias.Add(Data.MetadataImage);
            return Data;
        }
    }
}