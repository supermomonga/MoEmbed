using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Tombstone
    {
        [JsonPropertyName("text")]
        public Text Text { get; set; }
    }
}