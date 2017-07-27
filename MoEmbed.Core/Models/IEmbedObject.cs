using System;

namespace MoEmbed.Models
{
    public interface IEmbedObject
    {
        /// <summary>
        /// Gets the resource type. Valid values, along with value-specific parameters, are described below.
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the oEmbed version number. This must be <c>1.0</c>.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets a text title, describing the resource.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the name of the author/owner of the resource.
        /// </summary>
        string AuthorName { get; }

        /// <summary>
        /// Gets a URL for the author/owner of the resource.
        /// </summary>
        Uri AuthorUrl { get; }

        /// <summary>
        /// Gets the name of the resource provider.
        /// </summary>
        string ProviderName { get; }

        /// <summary>
        /// Gets the url of the resource provider.
        /// </summary>
        Uri ProviderUrl { get; }

        /// <summary>
        /// Gets the suggested cache lifetime for this resource, in seconds. Consumers may choose to use this value or not.
        /// </summary>
        int? CacheAge { get; }

        /// <summary>
        /// Gets a URL to a thumbnail image representing the resource.
        /// </summary>
        /// <remarks>
        /// The thumbnail must respect any <see cref="ConsumerRequest.MaxWidth"/> and <see cref="ConsumerRequest.MaxHeight"/> parameters.
        /// If this parameter is present, <see cref="ThumbnailWidth" /> and <see cref="ThumbnailHeight" /> must also be present.
        /// </remarks>
        Uri ThumbnailUrl { get; }

        /// <summary>
        /// Gets the width of the optional thumbnail.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="ThumbnailUrl" /> and <see cref="ThumbnailHeight" /> must also be present.
        /// </remarks>
        int? ThumbnailWidth { get; }

        /// <summary>
        /// Gets the height of the optional thumbnail.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="ThumbnailUrl" /> and <see cref="ThumbnailWidth" /> must also be present.
        /// </remarks>
        int? ThumbnailHeight { get; }
    }
}