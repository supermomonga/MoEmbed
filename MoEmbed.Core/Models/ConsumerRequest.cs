using System;

namespace MoEmbed.Models
{
    public sealed class ConsumerRequest
    {
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