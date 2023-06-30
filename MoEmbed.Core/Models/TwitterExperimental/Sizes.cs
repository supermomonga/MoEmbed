using System.Text.Json.Serialization;

// Tweet myDeserializedClass = JsonConvert.DeserializeObject<Tweet>(myJsonResponse);
namespace MoEmbed.Models.TweetExperimental
{
    public class Sizes
    {
        [JsonPropertyName("large")]
        public Large Large { get; set; }

        [JsonPropertyName("medium")]
        public Media Medium { get; set; }

        [JsonPropertyName("small")]
        public Small Small { get; set; }

        [JsonPropertyName("thumb")]
        public Thumb Thumb { get; set; }
    }
}