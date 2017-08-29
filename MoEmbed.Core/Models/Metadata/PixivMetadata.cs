using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            Uri uri;
            if (restrictionPolicy == RestrictionPolicies.Restricted)
            {
                uri = new Uri(sensoredImage.Replace("64x64", "128x128"));
                Data.Title = title.Replace("[R-18]", "");
            }
            else
            {
                var image = hd.DocumentNode.SelectSingleNode("//div[@class='img-container']/a/img")?.Attributes["src"]?.Value;
                uri = new Uri(image);
                Data.Title = title;
            }
            var media = new Media
            {
                Type = MediaTypes.Image,
                Thumbnail = new ImageInfo
                {
                    Url = uri,
                    Width = 128,
                    Height = 128
                },
                RawUrl = uri,
                Location = uri,
                RestrictionPolicy = restrictionPolicy
            };
            Data.Medias.Insert(0, media);
            Data.MetadataImage = media;
            Data.RestrictionPolicy = restrictionPolicy;
        }

    }
}
