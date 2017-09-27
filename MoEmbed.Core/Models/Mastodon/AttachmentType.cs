using System.Runtime.Serialization;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a type of the attatchment.
    /// </summary>
    [DataContract]
    public enum AttachmentType
    {
        /// <summary>
        /// The Attachement is an image.
        /// </summary>
        [EnumMember(Value = "image")]
        Image,

        /// <summary>
        /// The Attachement is a video.
        /// </summary>
        [EnumMember(Value = "video")]
        Video,

        /// <summary>
        /// The Attachement is a gifv.
        /// </summary>
        [EnumMember(Value = "gifv")]
        Gifv,

        /// <summary>
        /// The Attachement type is unknown.
        /// </summary>
        [EnumMember(Value = "unknown")]
        Unknown
    }
}