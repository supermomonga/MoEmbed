using System.Runtime.Serialization;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a visibility of the Status.
    /// </summary>
    [DataContract]
    public enum StatusVisibility
    {
        /// <summary>
        /// The status is public.
        /// </summary>
        [EnumMember(Value = "public")]
        Public,

        /// <summary>
        /// The status is private.
        /// </summary>
        [EnumMember(Value = "private")]
        Private,

        /// <summary>
        /// The status is direct.
        /// </summary>
        [EnumMember(Value = "direct")]
        Direct
    }
}