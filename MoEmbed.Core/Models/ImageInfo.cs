using System;

namespace MoEmbed.Models
{
    public class ImageInfo
    {
        /// <summary>
        /// Image URL
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the width of the image.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="Url" /> must also be present.
        /// </remarks>
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the image.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="Url" /> must also be present.
        /// </remarks>
        public int? Height { get; set; }
    }
}

