using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Large
    {
        [JsonPropertyName("h")]
        public int H { get; set; }

        [JsonPropertyName("resize")]
        public string Resize { get; set; }

        [JsonPropertyName("w")]
        public int W { get; set; }
    }
}