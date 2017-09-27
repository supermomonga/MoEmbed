using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a root of the <see cref="AttachmentMeta" />.
    /// </summary>
    [DataContract]
    public sealed class AttachmentMetaCollection
    {
        /// <summary>
        /// Gets or sets the metadata of the original.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("original")]
        public AttachmentMeta Original { get; set; }

        /// <summary>
        /// Gets or sets the metadata of the small.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("small")]
        public AttachmentMeta Small { get; set; }
    }
}