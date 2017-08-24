using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a result fetched by <see cref="Metadata.Metadata"/>
    /// </summary>
    public class EmbedData
    {
        /// <summary>
        /// Gets or sets a text title, describing the resource.
        /// </summary>
        [DefaultValue(null)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a description
        /// </summary>
        [DefaultValue(null)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the author/owner of the resource.
        /// </summary>
        [DefaultValue(null)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets a URL for the author/owner of the resource.
        /// </summary>
        [DefaultValue(null)]
        public Uri AuthorUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource provider.
        /// </summary>
        [DefaultValue(null)]
        public string ProviderName { get; set; }

        /// <summary>
        /// Gets or sets the url of the resource provider.
        /// </summary>
        [DefaultValue(null)]
        public Uri ProviderUrl { get; set; }

        /// <summary>
        /// Gets or sets the suggested cache lifetime for this resource, in seconds. Consumers may choose to use this value or not.
        /// </summary>
        [DefaultValue(86400)]
        public int? CacheAge { get; set; } = 86400;

        /// <summary>
        /// Gets or sets a URL to a thumbnail image representing the resource.
        /// </summary>
        /// <remarks>
        /// The thumbnail must respect any <see cref="ConsumerRequest.MaxWidth"/> and <see cref="ConsumerRequest.MaxHeight"/> parameters.
        /// If this parameter is present, <see cref="ThumbnailWidth" /> and <see cref="ThumbnailHeight" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public Uri ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets the width of the optional thumbnail.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="ThumbnailUrl" /> and <see cref="ThumbnailHeight" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public int? ThumbnailWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the optional thumbnail.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="ThumbnailUrl" /> and <see cref="ThumbnailWidth" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public int? ThumbnailHeight { get; set; }

        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        public Uri Url { get; set; }

        /// <summary>
        /// Gets or sets a NSFW for content
        /// </summary>
        [DefaultValue(false)]
        public bool Nsfw { get; set; }

        #region Medias

        private List<Media> _Medias;

        /// <summary>
        /// Gets a list of media attached to the URL.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<Media> Medias
        {
            get
            {
                return _Medias ?? (_Medias = new List<Media>());
            }
            set
            {
                if (value != _Medias)
                {
                    _Medias?.Clear();
                    if (value?.Count > 0)
                    {
                        Medias.AddRange(value);
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