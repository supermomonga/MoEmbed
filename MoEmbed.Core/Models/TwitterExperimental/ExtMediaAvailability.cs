using System.Text.Json.Serialization;

namespace MoEmbed.Models.TweetExperimental
{
    public class ExtMediaAvailability
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}