using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a Mastodon instances API response.
    /// </summary>
    [DataContract]
    public sealed class InstancesResponse
    {
        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("instances")]
        public InstancesInstance[] Instances { get; set; }
    }
}