using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class OriginalInfo
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}