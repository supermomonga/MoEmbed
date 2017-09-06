using System;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

namespace MoEmbed.Models.Imgur
{
    /// <summary>
    /// Represents a image model in the responce from imgur.com
    /// </summary>
    public sealed class ImgurImage
    {
        /// <summary>
        /// Gets or sets the ID for the image
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the image.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a description of the image.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a time uploaded, epoch time
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("datetime")]
        public long Datetime { get; set; }

        /// <summary>
        /// Gets or sets a image MIME type.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets value indicating whether the image is the image animated
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty("animated")]
        public bool IsAnimated { get; set; }

        /// <summary>
        /// Gets or sets the width of the image in pixels
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the image in pixels
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the size of the image in bytes
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("size")]
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets the number of image views
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("views")]
        public int Views { get; set; }

        /// <summary>
        /// Gets or sets Bandwidth consumed by the image in bytes
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("bandwidth")]
        public long Bandwidth { get; set; }

        /// <summary>
        /// Gets or sets the section the image belongs in. (funny, cats, adviceanimals, wtf, etc)
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("section")]
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets the direct link to the the image.
        /// </summary>
        /// <remarks>
        /// if fetching an animated GIF that was over 20MB in original size, a .gif thumbnail will be returned
        /// </remarks>
        [DefaultValue(null)]
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets The .gifv link. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("gifv")]
        public string Gifv { get; set; }

        /// <summary>
        /// Gets or sets The direct link to the .mp4. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("mp4")]
        public string Mp4 { get; set; }

        /// <summary>
        /// Gets or sets The Content-Length of the .mp4. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        /// <remarks>.
        /// A zero value (0) is possible if the video has not yet been generated
        /// </remarks>
        [DefaultValue(0)]
        [JsonProperty("mp4_size")]
        public int Mp4Size { get; set; }

        /// <summary>
        /// Gets or sets Whether the image has a looping animation. Only available if the image is animated and type is 'image/gif'.
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty("looping")]
        public bool Looping { get; set; }

        /// <summary>
        /// Gets or sets Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the image is in gallery. <c>true</c> if the image has been submitted to the gallery; otherwise, <c>false</c>.
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty("in_gallery")]
        public bool InGallery { get; set; }

        internal Media ToMedia()
        {
            var thumbScale = Math.Min(320f / Math.Max(Width, Height), 1);

            var media = new Media()
            {
                RawUrl = Link,
                Location = "https://imgur.com/" + Id,
                Type = IsAnimated ? MediaTypes.Video : MediaTypes.Image,
                RestrictionPolicy = Nsfw == null ? RestrictionPolicies.Unknown
                                    : Nsfw.Value ? RestrictionPolicies.Restricted
                                    : RestrictionPolicies.Safe,
                Thumbnail = new ImageInfo()
                {
                    Url = "https://imgur.com/" + Id + "m" + Path.GetExtension(Link),
                    Width = (int)(Width * thumbScale),
                    Height = (int)(Height * thumbScale)
                }
            };
            return media;
        }
    }
}