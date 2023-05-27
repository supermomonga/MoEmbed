using HtmlAgilityPack;

using Portable.Xaml.Markup;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

            if (Data?.Medias?.FirstOrDefault() is var media && media != null)
            {
                if (media.Thumbnail.Url == null)
                {
                    media.Thumbnail = Data.MetadataImage.Thumbnail;
                }
                Data.Medias = new List<Media>() { media };
                if (media.Type == MediaTypes.Video)
                {
                    Data.Type = EmbedDataTypes.SingleVideo;
                }
                else if (media.Type == MediaTypes.Image)
                {
                    Data.Type = EmbedDataTypes.SingleImage;
                }
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