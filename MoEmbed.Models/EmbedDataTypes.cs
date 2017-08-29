using System.Runtime.Serialization;

namespace MoEmbed.Models
{
    [DataContract]
    public enum EmbedDataTypes
    {
        [EnumMember]
        MixedContent,

        [EnumMember]
        SingleImage,

        [EnumMember]
        SingleVideo,

        [EnumMember]
        SingleAudio
    }
}