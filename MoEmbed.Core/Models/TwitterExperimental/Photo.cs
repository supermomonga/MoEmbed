using System.Collections.Generic;
using System.Text.Json.Serialization;

// Tweet myDeserializedClass = JsonConvert.DeserializeObject<Tweet>(myJsonResponse);
namespace MoEmbed.Models.TweetExperimental
{
    public class Photo
    {
        [JsonPropertyName("backgroundColor")]
        public BackgroundColor BackgroundColor { get; set; }

        [JsonPropertyName("cropCandidates")]
        public List<object> CropCandidates { get; set; }

        [JsonPropertyName("expandedUrl")]
        public string ExpandedUrl { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }
    }
}