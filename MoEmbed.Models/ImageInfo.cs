using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a single image.
    /// </summary>
    [DataContract]
    public class ImageInfo
    {
        /// <summary>
        /// Gets or sets an Image URL
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets the width of the image.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="Url" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        [DataMember, JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the image.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="Url" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        [DataMember, JsonProperty("height")]
        public int? Height { get; set; }
    }
}