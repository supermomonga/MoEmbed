using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Portable.Xaml.Markup;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the <see href="gyazo.com"/>.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
    public class GyazoMetadata : UnknownMetadata
    {
        /// <inheritdoc />
        protected override void LoadHtml(HtmlDocument htmlDocument)
        {
            base.LoadHtml(htmlDocument);

            if (Data?.Medias?.Any() == true)
            {
                Data.Type = EmbedDataTypes.SingleImage;
            }
            else
            {
                var tu = Data.MetadataImage?.Thumbnail?.Url;
                if (tu != null)
                {
                    var em = Regex.Match(tu, @"-(jpg|png|gif)\.(jpg|png|gif)$");

                    var ext = em.Success ? "." + em.Groups[1].Value : Path.GetExtension(tu);

                    Data.Type = EmbedDataTypes.SingleImage;
                    Data.MetadataImage = null;
                    Data.Medias.Add(new Media()
                    {
                        Location = Data.Url,
                        RawUrl = $"https://i.gyazo.com/{Path.GetFileName(Data.Url)}{ext}",
                        Thumbnail = new ImageInfo()
                        {
                            Url = tu
                        }
                    });
                }
            }
        }
    }
}