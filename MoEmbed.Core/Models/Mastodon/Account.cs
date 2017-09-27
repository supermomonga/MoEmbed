using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a mastodon account.
    /// </summary>
    [DataContract]
    public sealed class Account
    {
        /// <summary>
        /// Gets or sets the ID of the account.
        /// </summary>
        [DefaultValue(0L)]
        [DataMember, JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the account.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("username")]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the value that equals username for local users, includes @domain for remote ones
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("acct")]
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the account's display name
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets boolean for when the account cannot be followed without waiting for approval first.
        /// </summary>
        [DefaultValue(false)]
        [DataMember, JsonProperty("locked")]
        public bool IsLocked { get; set; }

        /// <summary>
        /// Gets or sets the time the account was created
        /// </summary>
        [DefaultValue(typeof(DateTimeOffset), "0001-01-01T00:00:00Z")]
        [DataMember, JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the number of followers for the account
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// Gets or sets the number of accounts the given account is following
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("following_count")]
        public int FollowingCount { get; set; }

        /// <summary>
        /// Gets or sets the number of statuses the account has made
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("statuses_count")]
        public int StatusesCount { get; set; }

        /// <summary>
        /// Gets or sets Biography of user
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets URL of the user's profile page (can be remote)
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets URL to the avatar image
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets URL to the avatar static image (gif)
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("avatar_static")]
        public string AvatarStatic { get; set; }

        /// <summary>
        /// Gets or sets URL to the header image
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("header")]
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets URL to the header static image (gif)
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("header_static")]
        public string HeaderStatic { get; set; }
    }

    //[DataContract] public sealed class Card
    // {
    //     /// <summary>
    //     /// Gets or sets the url associated with the card
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("url")]
    //     public string url { get; set; }

    //     /// <summary>
    //     /// Gets or sets the title of the card
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("title")]
    //     public string title { get; set; }

    //     /// <summary>
    //     /// Gets or sets the card description
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("description")]
    //     public string description { get; set; }

    //     /// <summary>
    //     /// Gets or sets the image associated with the card, if any
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("image")]
    //     public string image { get; set; }

    //     /// <summary>
    //     /// Gets or sets "link", "photo", "video", or "rich"
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("type")]
    //     public string type { get; set; }

    //     /// <summary>
    //     /// Gets or sets OEmbed data
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("author_name")]
    //     public string author_name { get; set; }

    //     /// <summary>
    //     /// Gets or sets OEmbed data
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("author_url")]
    //     public string author_url { get; set; }

    //     /// <summary>
    //     /// Gets or sets OEmbed data
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("provider_name")]
    //     public string provider_name { get; set; }

    //     /// <summary>
    //     /// Gets or sets OEmbed data
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("provider_url")]
    //     public string provider_url { get; set; }

    //     /// <summary>
    //     /// Gets or sets OEmbed data
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("html")]
    //     public string html { get; set; }

    //     /// <summary>
    //     /// Gets or sets OEmbed data
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("width")]
    //     public string width { get; set; }

    //     /// <summary>
    //     /// Gets or sets OEmbed data
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("height")]
    //     public string height { get; set; }
    // }

    // [DataContract]
    // public sealed class Context
    // {
    //     /// <summary>
    //     /// Gets or sets the ancestors of the status in the conversation, as a list of Statuses
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("ancestors")]
    //     public string ancestors { get; set; }

    //     /// <summary>
    //     /// Gets or sets the descendants of the status in the conversation, as a list of Statuses
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("descendants")]
    //     public string descendants { get; set; }
    // }

    // [DataContract]
    // public sealed class Error
    // {
    //     /// <summary>
    //     /// Gets or sets A textual description of the error
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("error")]
    //     public string error { get; set; }
    // }
    // [DataContract]
    // public sealed class Instance
    // {
    //     /// <summary>
    //     /// Gets or sets URI of the current instance
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("uri")]
    //     public string uri { get; set; }

    //     /// <summary>
    //     /// Gets or sets the instance's title
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("title")]
    //     public string title { get; set; }

    //     /// <summary>
    //     /// Gets or sets A description for the instance
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("description")]
    //     public string description { get; set; }

    //     /// <summary>
    //     /// Gets or sets An email address which can be used to contact the instance administrator
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("email")]
    //     public string email { get; set; }

    //     /// <summary>
    //     /// Gets or sets the Mastodon version used by instance.
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("version")]
    //     public string version { get; set; }

    //     /// <summary>
    //     /// Gets or sets streaming_api
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("urls")]
    //     public string urls { get; set; }
    // }
    // [DataContract]
    // public sealed class Notification
    // {
    //     /// <summary>
    //     /// Gets or sets the notification ID
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("id")]
    //     public string id { get; set; }

    //     /// <summary>
    //     /// Gets or sets One of: "mention", "reblog", "favourite", "follow"
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("type")]
    //     public string type { get; set; }

    //     /// <summary>
    //     /// Gets or sets the time the notification was created
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("created_at")]
    //     public string created_at { get; set; }

    //     /// <summary>
    //     /// Gets or sets the Account sending the notification to the user
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("account")]
    //     public string account { get; set; }

    //     /// <summary>
    //     /// Gets or sets the Status associated with the notification, if applicable
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("status")]
    //     public string status { get; set; }
    // }
    // [DataContract]
    // public sealed class Relationship
    // {
    //     /// <summary>
    //     /// Gets or sets Target account id
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("id")]
    //     public string id { get; set; }

    //     /// <summary>
    //     /// Gets or sets Whether the user is currently following the account
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("following")]
    //     public string following { get; set; }

    //     /// <summary>
    //     /// Gets or sets Whether the user is currently being followed by the account
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("followed_by")]
    //     public string followed_by { get; set; }

    //     /// <summary>
    //     /// Gets or sets Whether the user is currently blocking the account
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("blocking")]
    //     public string blocking { get; set; }

    //     /// <summary>
    //     /// Gets or sets Whether the user is currently muting the account
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("muting")]
    //     public string muting { get; set; }

    //     /// <summary>
    //     /// Gets or sets Whether the user has requested to follow the account
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("requested")]
    //     public string requested { get; set; }

    //     /// <summary>
    //     /// Gets or sets Whether the user is currently blocking the accounts's domain
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("domain_blocking")]
    //     public string domain_blocking { get; set; }
    // }
    // [DataContract]
    // public sealed class Report
    // {
    //     /// <summary>
    //     /// Gets or sets the ID of the report
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("id")]
    //     public string id { get; set; }

    //     /// <summary>
    //     /// Gets or sets the action taken in response to the report
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("action_taken")]
    //     public string action_taken { get; set; }
    // }
    // [DataContract]
    // public sealed class Results
    // {
    //     /// <summary>
    //     /// Gets or sets An array of matched Accounts
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("accounts")]
    //     public MastodonAccount[] Accounts { get; set; }

    //     /// <summary>
    //     /// Gets or sets An array of matched Statuses
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("statuses")]
    //     public MastodonStatus[] Statuses { get; set; }

    //     /// <summary>
    //     /// Gets or sets An array of matched hashtags, as strings
    //     /// </summary>
    //     [DefaultValue(null)]
    //     [DataMember, JsonProperty("hashtags")]
    //     public string[] HashTags { get; set; }
    // }
}