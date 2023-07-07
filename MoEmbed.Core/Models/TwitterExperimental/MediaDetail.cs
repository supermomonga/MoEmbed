using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class MediaDetail
    {
        [JsonPropertyName("display_url")]
        public string DisplayUrl { get; set; }

        [JsonPropertyName("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonPropertyName("ext_media_availability")]
        public ExtMediaAvailability ExtMediaAvailability { get; set; }

        [JsonPropertyName("indices")]
        public List<int> Indices { get; set; }

        [JsonPropertyName("media_url_https")]
        public string MediaUrlHttps { get; set; }

        [JsonPropertyName("original_info")]
        public OriginalInfo OriginalInfo { get; set; }

        [JsonPropertyName("sizes")]
        public Sizes Sizes { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}