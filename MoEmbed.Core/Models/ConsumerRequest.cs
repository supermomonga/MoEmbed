using System;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents a request of consumer.
    /// </summary>
    public sealed class ConsumerRequest
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ConsumerRequest" /> class with the specified URL.
        /// </summary>
        /// <param name="url">The URL to retrieve embedding information for.</param>
        public ConsumerRequest(Uri url)
        {
            Url = url;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ConsumerRequest" /> class with full parameters.
        /// </summary>
        /// <param name="url">The URL to retrieve embedding information for.</param>
        /// <param name="maxWidth">The maximum width of the embedded resource.</param>
        /// <param name="maxHeight">The maximum height of the embedded resource.</param>
        /// <param name="format">The required response format.</param>
        public ConsumerRequest(Uri url, int? maxWidth, int? maxHeight, string format)
        {
            Url = url;
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            Format = format;
        }

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