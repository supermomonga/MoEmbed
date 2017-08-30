using System;
using System.ComponentModel;
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
        /// Gets the unique identifier of the illust.
        /// </summary>
        [DefaultValue(0)]
        public int IllustId { get; set; }

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
            Data.Title = Data.Title.Replace("[pixiv]", "");
            var sensoredImage = hd.DocumentNode.SelectSingleNode("//div[@class='sensored']/img")?.Attributes["src"]?.Value;
            var restrictionPolicy = string.IsNullOrEmpty(sensoredImage) ? RestrictionPolicies.Unknown : RestrictionPolicies.Restricted;
            if (restrictionPolicy == RestrictionPolicies.Restricted)
            {
                var illustUri = new Uri(sensoredImage.Replace("64x64", "128x128"));
                Data.Medias.Insert(0, new Media {
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
            }
            else
            {
                var illustUri = new Uri($"http://embed.pixiv.net/decorate.php?illust_id={ IllustId }");
                Data.Medias.Insert(0, new Media {
                        Type = MediaTypes.Image,
                        Thumbnail = new ImageInfo
                        {
                            Url = illustUri,
                            Width = 600
                        },
                        RawUrl = illustUri,
                        Location = new Uri(Uri),
                        RestrictionPolicy = restrictionPolicy
                    });
            }

            Data.MetadataImage = null;
            Data.RestrictionPolicy = restrictionPolicy;

            return hd;
        }
    }
}
