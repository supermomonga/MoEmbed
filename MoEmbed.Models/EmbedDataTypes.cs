using System.Runtime.Serialization;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a type of of <see cref="EmbedData"/>.
    /// </summary>
    [DataContract]
    public enum EmbedDataTypes
    {
        /// <summary>
        /// The location contains mixed contents.
        /// </summary>
        [EnumMember]
        MixedContent,

        /// <summary>
        /// The location contains an image.
        /// </summary>
        [EnumMember]
        SingleImage,

        /// <summary>
        /// The location contains a video.
        /// </summary>
        [EnumMember]
        SingleVideo,

        /// <summary>
        /// The location contains an audio.
        /// </summary>
        [EnumMember]
        SingleAudio
    }
}