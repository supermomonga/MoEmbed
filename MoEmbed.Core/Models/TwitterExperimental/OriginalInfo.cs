using System.Text.Json.Serialization;

// Tweet myDeserializedClass = JsonConvert.DeserializeObject<Tweet>(myJsonResponse);
namespace MoEmbed.Models.TweetExperimental
{
    public class OriginalInfo
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}