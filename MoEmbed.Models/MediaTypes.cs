using System.Runtime.Serialization;

namespace MoEmbed.Models
{
    [DataContract]
    public enum MediaTypes
    {
        [EnumMember]
        Image,

        [EnumMember]
        Video,

        [EnumMember]
        Audio
    }
}