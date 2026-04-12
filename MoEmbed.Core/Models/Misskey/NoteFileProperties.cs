using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Misskey
{
    /// <summary>
    /// Represents properties of a Misskey note file.
    /// </summary>
    [DataContract]
    public sealed class NoteFileProperties
    {
        /// <summary>
        /// Gets or sets the width of the file.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the file.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("height")]
        public int? Height { get; set; }
    }
}
