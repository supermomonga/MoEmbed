using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Portable.Xaml.Markup;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a media information.
    /// </summary>
    [DataContract]
    [ContentProperty(nameof(Thumbnail))]
    public class Media
    {
        /// <summary>
        /// Gets the media type. Valid values, along with value-specific parameters, are described below.
        /// </summary>
        [DefaultValue(default(MediaTypes))]
        [DataMember, JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MediaTypes Type { get; set; }

        /// <summary>
        /// Gets or sets a Thumbnail image URL
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("thumbnail")]
        public ImageInfo Thumbnail { get; set; }

        /// <summary>
        /// Gets or sets a Raw resouce URL
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("raw_url")]
        public string RawUrl { get; set; }

        /// <summary>
        /// Gets or sets a URL of Media resouce. The resouce can be HTML page which contains the media.
        /// It doesn't have to be a raw media.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets a content restriction policy that applied to the media.
        /// </summary>
        [DefaultValue(RestrictionPolicies.Unknown)]
        [DataMember, JsonProperty("restriction_policy")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RestrictionPolicies RestrictionPolicy { get; set; } = RestrictionPolicies.Unknown;
    }
}