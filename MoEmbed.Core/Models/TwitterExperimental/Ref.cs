using System;
using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Ref
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("url_type")]
        public string UrlType { get; set; }
    }
}