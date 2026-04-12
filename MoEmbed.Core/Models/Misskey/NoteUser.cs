using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Misskey
{
    /// <summary>
    /// Represents a Misskey user associated with a note.
    /// </summary>
    [DataContract]
    public sealed class NoteUser
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the user.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the host of the user. Null for local users.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("host")]
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the avatar URL of the user.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }
    }
}
