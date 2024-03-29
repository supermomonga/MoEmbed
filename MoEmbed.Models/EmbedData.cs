using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Portable.Xaml.Markup;

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a result fetched by the Metadata.
    /// </summary>
    [DataContract]
    [ContentProperty(nameof(Medias))]
    public class EmbedData
    {
        /// <summary>
        /// Gets or sets a resource type. Value is <see cref="EmbedDataTypes"/>
        /// </summary>
        [DefaultValue(EmbedDataTypes.MixedContent)]
        [DataMember, JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EmbedDataTypes Type { get; set; } = EmbedDataTypes.MixedContent;

        /// <summary>
        /// Gets or sets a text title, describing the resource.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a description
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the author/owner of the resource.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("author_name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets a URL for the author/owner of the resource.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("author_url")]
        public string AuthorUrl { get; set; }

        /// <summary>
        /// Gets or sets a HTML of the content.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("html")]
        public string Html { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource provider.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("provider_name")]
        public string ProviderName { get; set; }

        /// <summary>
        /// Gets or sets the url of the resource provider.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("provider_url")]
        public string ProviderUrl { get; set; }

        /// <summary>
        /// Gets or sets the suggested cache lifetime for this resource, in seconds. Consumers may choose to use this value or not.
        /// </summary>
        [DefaultValue(86400L)]
        [DataMember, JsonProperty("cache_age")]
        public long? CacheAge { get; set; } = 86400;

        /// <summary>
        /// Gets or sets a URL to a thumbnail image representing the resource.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("metadata_image")]
        public Media MetadataImage { get; set; }

        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        [DataMember, JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets a content restriction policy that applied to the URL.
        /// </summary>
        [DefaultValue(RestrictionPolicies.Unknown)]
        [DataMember, JsonProperty("restriction_policy")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RestrictionPolicies RestrictionPolicy { get; set; } = RestrictionPolicies.Unknown;

        #region Medias

        private MediaCollection _Medias;

        /// <summary>
        /// Gets a list of media attached to the URL.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DataMember, JsonProperty("medias")]
        public IList<Media> Medias
        {
            get
            {
                return _Medias ?? (_Medias = new MediaCollection());
            }
            set
            {
                if (value != _Medias)
                {
                    _Medias?.Clear();
                    if (value?.Count > 0)
                    {
                        foreach (var m in value)
                        {
                            Medias.Add(m);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns whether serialization processes should serialize the contents of the <see cref="Medias"/> property on instances of this class.
        /// </summary>
        /// <returns><c>true</c> if the <see cref="Medias"/> property value should be serialized; otherwise, <c>false</c>.</returns>
        public bool ShouldSerializeMedias()
            => _Medias?.Count > 0;

        #endregion Medias
    }
}