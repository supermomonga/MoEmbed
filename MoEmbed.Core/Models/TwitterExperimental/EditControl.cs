using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoEmbed.Models.TwitterExperimental
{
    public class EditControl
    {
        [JsonPropertyName("edit_tweet_ids")]
        public List<string> EditTweetIds { get; set; }

        [JsonPropertyName("editable_until_msecs")]
        public string EditableUntilMsecs { get; set; }

        [JsonPropertyName("is_edit_eligible")]
        public bool IsEditEligible { get; set; }

        [JsonPropertyName("edits_remaining")]
        public string EditsRemaining { get; set; }
    }
}