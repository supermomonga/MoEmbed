using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents an instance returned by the Mastodon instances API.
    /// </summary>
    [DataContract]
    public sealed class InstancesInstance
    {
        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("name")]
        public string Name { get; set; }
    }
}