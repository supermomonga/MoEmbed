using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using MoEmbed.Providers;
using Portable.Xaml.Markup;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the <see href="amazon.com"/>.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
    public class AmazonExperimentalMetadata : UnknownMetadata
    {
        private static readonly Regex imageRegex = new Regex("{&quot;(?<image>https://.+?\\.jpg)");

        internal AmazonExperimentalMetadataProvider Provider { get; set; }

        /// <summary>
        /// Gets or sets the destination domain of marketplace.
        /// </summary>
        [DefaultValue(null)]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the ASIN.
        /// </summary>
        [DefaultValue(null)]
        public string Asin { get; set; }

        /// <inheritdoc />
        protected override void LoadHtml(HtmlDocument htmlDocument)
        {
            base.LoadHtml(htmlDocument);
            var m = imageRegex.Match(htmlDocument.GetElementbyId("landingImage")?.GetAttributeValue("data-a-dynamic-image", null) ?? "");

            var associateUri = $"https://{Destination}/dp/{Asin}?tag={Provider.AssociateTag}";
            if (m.Success)
            {
                var tu = m.Groups["image"].Value;
                Data.Type = EmbedDataTypes.MixedContent;
                Data.Url = associateUri;
                Data.MetadataImage = null;
                Data.Medias.Add(new Media()
                {
                    // TODO: Support Detail page URL
                    Location = associateUri,
                    RawUrl = associateUri,
                    Thumbnail = new ImageInfo()
                    {
                        Url = tu
                    }
                });
            }
            else
            {
                Data.Url = associateUri;
            }
        }
    }
}
