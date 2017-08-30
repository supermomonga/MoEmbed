using System;
using HtmlAgilityPack;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the <see href="pixiv.net"/>.
    /// </summary>
    [Serializable]
    public class PixivMetadata : UnknownMetadata
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PixivMetadata" /> class.
        /// </summary>
        public PixivMetadata()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="PixivMetadata" /> class with the specified url.
        /// </summary>
        /// <param name="uri">The resource URL.</param>
        public PixivMetadata(string uri)
        {
            Uri = uri;
        }

        /// <inheritdoc />
        protected override HtmlDocument LoadHtml(string html)
        {
            var hd = base.LoadHtml(html);

            var title = hd.DocumentNode.SelectSingleNode("//meta[@property='twitter:title']")?.Attributes["content"]?.Value;
            var sensoredImage = hd.DocumentNode.SelectSingleNode("//div[@class='sensored']/img")?.Attributes["src"]?.Value;
            var restrictionPolicy = string.IsNullOrEmpty(sensoredImage) ? RestrictionPolicies.Unknown : RestrictionPolicies.Restricted;
            Uri illustUri;
            if (restrictionPolicy == RestrictionPolicies.Restricted)
            {
                illustUri = new Uri(sensoredImage.Replace("64x64", "128x128"));
                Data.Title = title.Replace("[R-18]", "");
            }
            else
            {
                var image = hd.DocumentNode.SelectSingleNode("//div[@class='img-container']/a/img")?.Attributes["src"]?.Value;
                illustUri = new Uri(image);
                Data.Title = title;
            }
            Data.Medias.Insert(0, new Media
            {
                Type = MediaTypes.Image,
                Thumbnail = new ImageInfo
                {
                    Url = illustUri,
                    Width = 128,
                    Height = 128
                },
                RawUrl = illustUri,
                Location = new Uri(Uri),
                RestrictionPolicy = restrictionPolicy
            });

            Data.RestrictionPolicy = restrictionPolicy;

            return hd;
        }
    }
}
