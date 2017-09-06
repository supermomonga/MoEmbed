using System.ComponentModel;
using Newtonsoft.Json;

namespace MoEmbed.Models.Imgur
{
    /// <summary>
    /// Represents a album model in the responce from imgur.com
    /// </summary>
    public sealed class ImgurAlbum
    {
        /// <summary>
        /// Gets or sets the ID for the album
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the album in the gallery
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description of the album in the gallery
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets time inserted into the gallery, epoch time
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("datetime")]
        public long Datetime { get; set; }

        /// <summary>
        /// Gets or sets the ID of the album cover image
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("cover")]
        public string Cover { get; set; }

        /// <summary>
        /// Gets or sets the width, in pixels, of the album cover image
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("cover_width")]
        public int CoverWidth { get; set; }

        /// <summary>
        /// Gets or sets the height, in pixels, of the album cover image
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("cover_height")]
        public int CoverHeight { get; set; }

        /// <summary>
        /// Gets or sets the account username or null if it's anonymous.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("accountUrl")]
        public string AccountUrl { get; set; }

        /// <summary>
        /// Gets or sets the account ID or null if it's anonymous.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the view layout of the album.
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("layout")]
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets the number of album views
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("views")]
        public int Views { get; set; }

        /// <summary>
        /// Gets or sets the URL link to the album
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets Indicates if the image has been marked as nsfw or not. Defaults to null if information is not available.
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty("nsfw")]
        public bool? Nsfw { get; set; }

        /// <summary>
        /// Gets or sets the section the image belongs in. (funny, cats, adviceanimals, wtf, etc)
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("section")]
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets Order number of the album on the user's album page (defaults to 0 if their albums haven't been reordered)
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the total number of images in the album
        /// </summary>
        [DefaultValue(0)]
        [JsonProperty("images_count")]
        public int ImagesCount { get; set; }

        /// <summary>
        /// Gets or sets an array of all the images in the album (only available when requesting the direct album)
        /// </summary>
        [DefaultValue(null)]
        [JsonProperty("images")]
        public ImgurImage[] Images { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the image is in gallery. <c>true</c> if the image has been submitted to the gallery; otherwise, <c>false</c>.
        /// </summary>
        [DefaultValue(false)]
        [JsonProperty("in_gallery")]
        public bool InGallery { get; set; }
    }
}