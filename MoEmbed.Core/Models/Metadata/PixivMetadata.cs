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

        /// <inheritdoc />
        protected override HtmlDocument LoadHtml(string html)
        {
            var hd = base.LoadHtml(html);
            Data.Title = Data.Title.Replace("[pixiv]", "");
            var sensoredImage = hd.DocumentNode.SelectSingleNode("//div[@class='sensored']/img")?.Attributes["src"]?.Value;
            var restrictionPolicy = string.IsNullOrEmpty(sensoredImage) ? RestrictionPolicies.Unknown : RestrictionPolicies.Restricted;
            if (restrictionPolicy == RestrictionPolicies.Restricted)
            {
                var illustUri = sensoredImage.Replace("64x64", "128x128");
                Data.MetadataImage = new Media
                {
                    Type = MediaTypes.Image,
                    Thumbnail = new ImageInfo
                    {
                        Url = illustUri,
                        Width = 128,
                        Height = 128
                    },
                    RawUrl = illustUri,
                    Location = Url.ToString(),
                    RestrictionPolicy = restrictionPolicy
                };
            }
            else
            {
                var illustUri = $"http://embed.pixiv.net/decorate.php?illust_id={ IllustId }";
                Data.MetadataImage = new Media
                {
                    Type = MediaTypes.Image,
                    Thumbnail = new ImageInfo
                    {
                        Url = illustUri,
                        Width = 600
                    },
                    RawUrl = illustUri,
                    Location = Url.ToString(),
                    RestrictionPolicy = restrictionPolicy
                };
            }

            Data.Medias.Clear();
            Data.RestrictionPolicy = restrictionPolicy;

            return hd;
        }
    }
}