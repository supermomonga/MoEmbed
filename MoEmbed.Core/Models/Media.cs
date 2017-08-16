using System;

namespace MoEmbed.Models
{
    public enum MediaTypes { Image, Video, Audio }

    public class Media
    {
        /// <summary>
        /// Gets the media type. Valid values, along with value-specific parameters, are described below.
        /// </summary>
        public MediaTypes Type { get; set; }

        /// <summary>
        /// Thumbnail image URL
        /// </summary>
        public Uri ThumbnailUri { get; set; }

        /// <summary>
        /// Raw resouce URL
        /// </summary>
        public Uri RawUri { get; set; }

        /// <summary>
        /// URL of Media resouce. The resouce can be HTML page which contains the media.
        /// It doesn't have to be a raw media.
        /// </summary>
        public Uri Location { get; set; }
    }
}

