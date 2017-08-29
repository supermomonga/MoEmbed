using System.Runtime.Serialization;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a type of of <see cref="Media"/>.
    /// </summary>
    [DataContract]
    public enum MediaTypes
    {
        /// <summary>
        /// The media is an image.
        /// </summary>
        [EnumMember]
        Image,

        /// <summary>
        /// The media is a video.
        /// </summary>
        [EnumMember]
        Video,

        /// <summary>
        /// The media is an audio.
        /// </summary>
        [EnumMember]
        Audio
    }
}