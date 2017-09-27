using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a mastodon tag.
    /// </summary>
    [DataContract]
    public sealed class Tag
    {
        /// <summary>
        /// Gets or sets the hashtag, not including the preceding #
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL of the hashtag
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("url")]
        public string Url { get; set; }
    }
}