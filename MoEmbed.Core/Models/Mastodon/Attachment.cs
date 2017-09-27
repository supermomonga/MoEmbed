using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a mastodon attachment
    /// </summary>
    [DataContract]
    public sealed class Attachment
    {
        /// <summary>
        /// Gets or sets ID of the attachment
        /// </summary>
        [DefaultValue(0L)]
        [DataMember, JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets a type of the attachement.
        /// </summary>
        [DefaultValue(default(AttachmentType))]
        [DataMember, JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AttachmentType Type { get; set; }

        /// <summary>
        /// Gets or sets URL of the locally hosted version of the image
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets For remote images, the remote URL of the original image
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("remote_url")]
        public string RemoteUrl { get; set; }

        /// <summary>
        /// Gets or sets URL of the preview image
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        /// <summary>
        /// Gets or sets Shorter URL for the image, for insertion into text (only present on local images)
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("text_url")]
        public string TextUrl { get; set; }

        /// <summary>
        /// Gets or sets small and original containing: width, height, size, aspect
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("meta")]
        public AttachmentMetaCollection Meta { get; set; }
    }
}