using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a size information of the <see cref="Attachment" />.
    /// </summary>
    [DataContract]
    public sealed class AttachmentMeta
    {
        /// <summary>
        /// Gets or sets the width of the image.
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("width")]
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the image.
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("height")]
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets a string that represents the size.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the aspect ratio.
        /// </summary>
        [DefaultValue(0f)]
        [DataMember, JsonProperty("aspect")]
        public float Aspect { get; set; }
    }
}