using System;
using HtmlAgilityPack;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the unknown URL.
    /// </summary>
    [Serializable]
    public class PixivMetadata : UnknownMetadata
    {
        public PixivMetadata()
        {
        }

        public PixivMetadata(string uri)
        {
            Uri = uri;
        }

        public PixivMetadata(Uri uri)
        {
            Uri = uri.ToString();
        }

        protected override void LoadHtml(string html)
        {
            base.LoadHtml(html);
            var hd = new HtmlDocument();
            hd.LoadHtml(html);
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

            var userIconUri = new Uri(hd.DocumentNode.SelectSingleNode("//div[@class='usericon']/a/img").Attributes["src"].Value);
            Data.MetadataImage = new Media
            {
                Type = MediaTypes.Image,
                Thumbnail = new ImageInfo
                {
                    Url = userIconUri,
                },
                RawUrl = userIconUri,
                Location = new Uri(Uri),
                RestrictionPolicy = RestrictionPolicies.Safe
            };
            Data.RestrictionPolicy = restrictionPolicy;
        }
    }
}