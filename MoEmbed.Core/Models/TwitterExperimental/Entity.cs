using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Entity
    {
        [JsonPropertyName("from_index")]
        public long FromIndex { get; set; }

        [JsonPropertyName("to_index")]
        public long ToIndex { get; set; }

        [JsonPropertyName("ref")]
        public Ref Ref { get; set; }
    }
}