using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MoEmbed.Models.Misskey
{
    /// <summary>
    /// Represents a Misskey note.
    /// </summary>
    [DataContract]
    public sealed class Note
    {
        /// <summary>
        /// Gets or sets the ID of the note.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the time the note was created.
        /// </summary>
        [DefaultValue(typeof(DateTimeOffset), "0001-01-01T00:00:00Z")]
        [DataMember, JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the user who posted the note.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("user")]
        public NoteUser User { get; set; }

        /// <summary>
        /// Gets or sets the text content of the note.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the content warning text.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("cw")]
        public string Cw { get; set; }

        /// <summary>
        /// Gets or sets the visibility of the note.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("visibility")]
        public string Visibility { get; set; }

        /// <summary>
        /// Gets or sets the files attached to the note.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("files")]
        public NoteFile[] Files { get; set; }

        /// <summary>
        /// Gets or sets the number of renotes.
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("renoteCount")]
        public int RenoteCount { get; set; }

        /// <summary>
        /// Gets or sets the number of replies.
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("repliesCount")]
        public int RepliesCount { get; set; }

        /// <summary>
        /// Gets or sets the number of reactions.
        /// </summary>
        [DefaultValue(0)]
        [DataMember, JsonProperty("reactionCount")]
        public int ReactionCount { get; set; }
    }
}
