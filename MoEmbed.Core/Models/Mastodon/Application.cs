using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a mastodon application.
    /// </summary>
    [DataContract]
    public sealed class Application
    {
        /// <summary>
        /// Gets or sets name of the app
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets homepage URL of the app
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("website")]
        public string WebSite { get; set; }
    }
}