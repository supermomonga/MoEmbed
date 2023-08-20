using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class Tweet
    {
        [JsonPropertyName("__typename")]
        public string Typename { get; set; }

        [JsonPropertyName("lang")]
        public string Lang { get; set; }

        [JsonPropertyName("favorite_count")]
        public int FavoriteCount { get; set; }

        [JsonPropertyName("possibly_sensitive")]
        public bool PossiblySensitive { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("display_text_range")]
        public List<int> DisplayTextRange { get; set; }

        [JsonPropertyName("entities")]
        public Entities Entities { get; set; }

        [JsonPropertyName("id_str")]
        public string IdStr { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("edit_control")]
        public EditControl EditControl { get; set; }

        [JsonPropertyName("mediaDetails")]
        public List<MediaDetail> MediaDetails { get; set; }

        [JsonPropertyName("photos")]
        public List<Photo> Photos { get; set; }

        [JsonPropertyName("conversation_count")]
        public int ConversationCount { get; set; }

        [JsonPropertyName("news_action_type")]
        public string NewsActionType { get; set; }

        [JsonPropertyName("isEdited")]
        public bool IsEdited { get; set; }

        [JsonPropertyName("isStaleEdit")]
        public bool IsStaleEdit { get; set; }

        [JsonPropertyName("tombstone")]
        public Tombstone Tombstone { get; set; }
    }
}