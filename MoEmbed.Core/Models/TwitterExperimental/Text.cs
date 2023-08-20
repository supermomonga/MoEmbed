using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Text
    {
        [JsonPropertyName("text")]
        public string TextText { get; set; }

        [JsonPropertyName("entities")]
        public Entity[] Entities { get; set; }

        [JsonPropertyName("rtl")]
        public bool Rtl { get; set; }
    }
}