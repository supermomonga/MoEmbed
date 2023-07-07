using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class UserMention
    {
        [JsonPropertyName("id_str")]
        public string IdStr { get; set; }

        [JsonPropertyName("indices")]
        public List<int> Indices { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("screen_name")]
        public string ScreenName { get; set; }
    }
}