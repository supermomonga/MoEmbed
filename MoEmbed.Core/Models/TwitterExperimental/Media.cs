using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Media
    {
        [JsonPropertyName("display_url")]
        public string DisplayUrl { get; set; }

        [JsonPropertyName("expanded_url")]
        public string ExpandedUrl { get; set; }

        [JsonPropertyName("indices")]
        public List<int> Indices { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}