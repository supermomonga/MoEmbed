using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Entities
    {
        [JsonPropertyName("hashtags")]
        public List<Hashtag> Hashtags { get; set; }

        [JsonPropertyName("urls")]
        public List<object> Urls { get; set; }

        [JsonPropertyName("user_mentions")]
        public List<UserMention> UserMentions { get; set; }

        [JsonPropertyName("symbols")]
        public List<object> Symbols { get; set; }

        [JsonPropertyName("media")]
        public List<Media> Media { get; set; }
    }
}