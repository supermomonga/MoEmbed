using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class User
    {
        [JsonPropertyName("id_str")]
        public string IdStr { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("profile_image_url_https")]
        public string ProfileImageUrlHttps { get; set; }

        [JsonPropertyName("screen_name")]
        public string ScreenName { get; set; }

        [JsonPropertyName("verified")]
        public bool Verified { get; set; }

        [JsonPropertyName("verified_type")]
        public string VerifiedType { get; set; }

        [JsonPropertyName("is_blue_verified")]
        public bool IsBlueVerified { get; set; }

        [JsonPropertyName("profile_image_shape")]
        public string ProfileImageShape { get; set; }
    }
}