using System.Runtime.Serialization;

namespace MoEmbed.Models
{
    [DataContract]
    public enum RestrictionPolicies
    {
        [EnumMember]
        Unknown,

        [EnumMember]
        Safe,

        [EnumMember]
        Restricted
    }
}