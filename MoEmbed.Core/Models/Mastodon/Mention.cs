using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a mastodon mention.
    /// </summary>
    [DataContract]
    public sealed class Mention
    {
        /// <summary>
        /// Gets or sets URL of user's profile (can be remote)
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the username of the account
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets a value that equals username for local users, includes @domain for remote ones
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("acct")]
        public string AccounntName { get; set; }

        /// <summary>
        /// Gets or sets an Account ID
        /// </summary>
        [DefaultValue(0L)]
        [DataMember, JsonProperty("id")]
        public long Id { get; set; }
    }
}