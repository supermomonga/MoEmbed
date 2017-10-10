using System;
using HtmlAgilityPack;
using Portable.Xaml.Markup;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the <see href="droplr.com"/>.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
    public class DroplrMetadata : UnknownMetadata
    {
        /// <inheritdoc />
        protected override void LoadHtml(HtmlDocument htmlDocument)
        {
            base.LoadHtml(htmlDocument);

            if (Data != null)
            {
                Data.Type = EmbedDataTypes.SingleImage;
                Data.Medias.Add(Data.MetadataImage);
            }
        }
    }
}