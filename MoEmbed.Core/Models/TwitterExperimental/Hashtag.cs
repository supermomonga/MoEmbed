using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Hashtag
    {
        [JsonPropertyName("indices")]
        public List<int> Indices { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}