using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class BackgroundColor
    {
        [JsonPropertyName("red")]
        public int Red { get; set; }

        [JsonPropertyName("green")]
        public int Green { get; set; }

        [JsonPropertyName("blue")]
        public int Blue { get; set; }
    }
}