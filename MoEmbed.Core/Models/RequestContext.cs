using System;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a request to  <see cref="Metadata.Metadata"/>.
    /// </summary>
    public sealed class RequestContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RequestContext" /> class with the specified <see cref="MetadataService" /> and <see cref="ConsumerRequest"/>.
        /// </summary>
        /// <param name="service">The <see cref="MetadataService"/> processing this request.</param>
        /// <param name="request">The request from consumer.</param>
        public RequestContext(MetadataService service, ConsumerRequest request)
        {
            Service = service;

            Url = request.Url;
            MaxWidth = request.MaxWidth;
            MaxHeight = request.MaxHeight;
            Format = request.Format;
        }

        /// <summary>
        /// Gets the <see cref="MetadataService" /> processing this request.
        /// </summary>
        public MetadataService Service { get; }

        /// <summary>
        /// Gets the URL to retrieve embedding information for.
        /// </summary>
        public Uri Url { get; }

        /// <summary>
        /// Gets the maximum width of the embedded resource.
        /// Only applies to some resource types.
        /// For supported resource types, this parameter must be respected by providers.
        /// </summary>
        public int? MaxWidth { get; }

        /// <summary>
        /// Gets the maximum height of the embedded resource.
        /// Only applies to some resource types.
        /// For supported resource types, this parameter must be respected by providers.
        /// </summary>
        public int? MaxHeight { get; }

        /// <summary>
        /// Gets the required response format.
        /// When not specified, the provider can return any valid response format.
        /// When specified, the provider must return data in the request format, else return an error.
        /// </summary>
        public string Format { get; }
    }
}