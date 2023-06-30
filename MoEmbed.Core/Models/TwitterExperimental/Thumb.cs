using System.Text.Json.Serialization;

// Tweet myDeserializedClass = JsonConvert.DeserializeObject<Tweet>(myJsonResponse);
namespace MoEmbed.Models.TweetExperimental
{
    public class Thumb
    {
        [JsonPropertyName("h")]
        public int H { get; set; }

        [JsonPropertyName("resize")]
        public string Resize { get; set; }

        [JsonPropertyName("w")]
        public int W { get; set; }
    }
}