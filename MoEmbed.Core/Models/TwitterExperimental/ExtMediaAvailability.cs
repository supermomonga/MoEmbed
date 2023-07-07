using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class ExtMediaAvailability
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}