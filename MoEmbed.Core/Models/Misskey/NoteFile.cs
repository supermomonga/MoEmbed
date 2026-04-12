using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Misskey
{
    /// <summary>
    /// Represents a file attached to a Misskey note.
    /// </summary>
    [DataContract]
    public sealed class NoteFile
    {
        /// <summary>
        /// Gets or sets the ID of the file.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the MIME type of the file.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the URL of the file.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail URL of the file.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets whether the file is marked as sensitive.
        /// </summary>
        [DefaultValue(false)]
        [DataMember, JsonProperty("isSensitive")]
        public bool IsSensitive { get; set; }

        /// <summary>
        /// Gets or sets the properties of the file (dimensions, etc.).
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("properties")]
        public NoteFileProperties Properties { get; set; }
    }
}
