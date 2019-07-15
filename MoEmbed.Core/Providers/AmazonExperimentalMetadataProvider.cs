using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a Amazon specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed class AmazonExperimentalMetadataProvider : IMetadataProvider
    {
        private static readonly Regex regex = new Regex(@"^https?://(www\.)?(?<dest>amazon\.(com(\.(br|mx))?|ca|cn|de|es|fr|in|it|co\.(jp|uk)))/+(([^/]+/+)?dp|gp/product)/+(?<asin>[A-Za-z0-9]{10})($|/|\?)");

        /// <summary>
        /// Initializes a new instaince of the <see cref="AmazonExperimentalMetadataProvider" /> class with AWS secrets.
        /// </summary>
        /// <param name="associateTag">The Amazon associate tag.</param>
        public AmazonExperimentalMetadataProvider(string associateTag)
            => AssociateTag = associateTag;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmazonMetadataProvider" /> with the
        /// configuration for Amazon.
        /// </summary>
        /// <param name="optionsAccessor">The accessor to the configuration for Amazon.</param>
        public AmazonExperimentalMetadataProvider(IOptions<AmazonMetadataOptions> optionsAccessor)
        {
            var op = optionsAccessor?.Value;
            AssociateTag = op?.AmazonAssociateTag ?? Environment.GetEnvironmentVariable("AMAZON_ASSOCIATE_TAG") ?? "";
        }

        /// <summary>
        /// The Amazon associate tag.
        /// </summary>
        public string AssociateTag { get; set; }

        bool IMetadataProvider.SupportsAnyHost
            => false;

        bool IMetadataProvider.IsEnabled
            => true;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
        {
            foreach (var p in new[] { null, "www." })
            {
                foreach (var d in new[] { "com", "com.br", "com.mx", "co.jp", "co.uk", "ca", "cn", "de", "es", "fr", "in", "it" })
                {
                    yield return p + "amazon." + d;
                }
            }
        }

        /// <summary>
        /// Determines whether this provider can handle the specified request.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// <c>true</c> if this provider can handle <paramref name="request" />; otherwise <c>false</c>.
        /// </returns>
        public bool CanHandle(ConsumerRequest request)
            => regex.IsMatch(request.Url.ToString());

        /// <summary>
        /// Returns a <see cref="Metadata" /> that represents the specified URL.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// The <see cref="UnknownMetadata" /> if this provider can handle <paramref name="request"
        /// />; otherwise <c>null</c>.
        /// </returns>
        public Metadata GetMetadata(ConsumerRequest request)
        {
            var m = regex.Match(request.Url.ToString());
            if (m.Success)
            {
                return new AmazonExperimentalMetadata()
                {
                    Provider = this,
                    Url = request.Url,
                    Destination = m.Groups["dest"].Value,
                    Asin = m.Groups["asin"].Value
                };
            }
            return null;
        }

        /// <summary>
        /// Returns a new instance of the <see cref="AmazonExperimentalMetadataProvider" /> class if configured.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The <see cref="AmazonExperimentalMetadataProvider" />.</returns>
        public static AmazonExperimentalMetadataProvider GetInstance(IConfigurationRoot configuration)
        {
            var tag = configuration["AmazonAssociateTag"] ?? Environment.GetEnvironmentVariable("AMAZON_ASSOCIATE_TAG");

            if (string.IsNullOrEmpty(tag))
            {
                return null;
            }
            return new AmazonExperimentalMetadataProvider(tag);
        }
    }
}
