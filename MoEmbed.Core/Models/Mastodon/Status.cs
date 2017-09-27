using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoEmbed.Models.Mastodon
{
    /// <summary>
    /// Represents a mastodon Status.
    /// </summary>
    [DataContract]
    public sealed class Status
    {
        /// <summary>
        /// Gets or sets the ID of the status
        /// </summary>
        [DefaultValue(0L)]
        [DataMember, JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets A Fediverse-unique resource ID.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets URL to the status page (can be remote)
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Account which posted the status
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("account")]
        public Account Account { get; set; }

        /// <summary>
        /// Gets or sets null or the ID of the status it replies to
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("in_reply_to_id")]
        public long? InReplyToId { get; set; }

        /// <summary>
        /// Gets or sets null or the ID of the account it replies to
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("in_reply_to_account_id")]
        public long? InReplyToAccountId { get; set; }

        /// <summary>
        /// Gets or sets null or the reblogged Status
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("reblog")]
        public Status Reblog { get; set; }

        /// <summary>
        /// Gets or sets a body of the status.
        /// </summary>
        /// <remarks>this will contain HTML. remote HTML already sanitized</remarks>
        [DefaultValue(null)]
        [DataMember, JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the time the status was created
        /// </summary>
        [DefaultValue(typeof(DateTimeOffset), "0001-01-01T00:00:00Z")]
        [DataMember, JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the number of reblogs for the status
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("reblogs_count")]
        public int ReblogsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of favourites for the status
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("favourites_count")]
        public int FavouritesCount { get; set; }

        /// <summary>
        /// Gets or sets indicating whether the authenticated user has reblogged the status
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("reblogged")]
        public bool? IsReblogged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the authenticated user has favourited the status
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("favourited")]
        public bool? IsFavourited { get; set; }

        /// <summary>
        /// Gets or sets a value indicationg whether the authenticated user has muted the
        /// conversation this status from
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("muted")]
        public bool? IsMuted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether media attachments should be hidden by default
        /// </summary>
        [DefaultValue(false)]
        [DataMember, JsonProperty("sensitive")]
        public bool IsSensitive { get; set; }

        /// <summary>
        /// Gets or sets If not empty, warning text that should be displayed before the actual content
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("spoiler_text")]
        public string SpoilerText { get; set; }

        /// <summary>
        /// Gets or sets the visibility of the status.
        /// </summary>
        [DefaultValue(default(StatusVisibility))]
        [DataMember, JsonProperty("visibility")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusVisibility Visibility { get; set; }

        /// <summary>
        /// Gets or sets an array of Attachments
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("media_attachments")]
        public Attachment[] MediaAttachments { get; set; }

        /// <summary>
        /// Gets or sets an array of Mentions
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("mentions")]
        public Mention[] Mentions { get; set; }

        /// <summary>
        /// Gets or sets an array of Tags
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("tags")]
        public Tag[] Tags { get; set; }

        /// <summary>
        /// Gets or sets an application from which the status was posted
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("application")]
        public Application Application { get; set; }

        /// <summary>
        /// Gets or sets the detected language for the status, if detected
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("language")]
        public string Language { get; set; }
    }
}