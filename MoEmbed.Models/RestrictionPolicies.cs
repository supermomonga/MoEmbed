using System.Runtime.Serialization;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a restriction policy type.
    /// </summary>
    [DataContract]
    public enum RestrictionPolicies
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        [EnumMember]
        Unknown,

        /// <summary>
        /// The safe resource.
        /// </summary>
        [EnumMember]
        Safe,

        /// <summary>
        /// The resource is not suitable for work.
        /// </summary>
        [EnumMember]
        Restricted
    }
}