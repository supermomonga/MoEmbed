using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a Amazon specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed class AmazonMetadataProvider : IMetadataProvider
    {
        private static readonly Regex regex = new Regex(@"^https?://(www\.)?(?<dest>amazon\.(com(\.(br|mx))?|ca|cn|de|es|fr|in|it|co\.(jp|uk)))/(([^/]+/)?dp|gp/product)/(?<asin>[A-Za-z0-9]{10})($|/|\?)");

        private readonly AmazonMetadataProviderQueue _Queue;

        /// <summary>
        /// Initializes a new instaince of the <see cref="AmazonMetadataProvider" /> class with AWS secrets.
        /// </summary>
        /// <param name="accessKeyId">The AWS access key id.</param>
        /// <param name="secretKey">The AWS secret key.</param>
        /// <param name="associateTag">The Amazon associate tag.</param>
        public AmazonMetadataProvider(string accessKeyId, string secretKey, string associateTag)
        {
            // TODO: support multiple queue.
            _Queue = new AmazonMetadataProviderQueue(accessKeyId, secretKey, associateTag);
        }

        bool IMetadataProvider.SupportsAnyHost
            => false;

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
        /// The <see cref="Metadata" /> if this provider can handle <paramref name="request" />;
        /// otherwise <c>null</c>.
        /// </returns>
        public Metadata GetMetadata(ConsumerRequest request)
        {
            var m = regex.Match(request.Url.ToString());
            if (!m.Success)
            {
                return null;
            }
            return new AmazonMetadata()
            {
                Provider = this,
                Destination = m.Groups["dest"].Value,
                Asin = m.Groups["asin"].Value
            };
        }

        internal Task<EmbedData> FetchAsync(HttpClient client, string destination, string asin)
            => _Queue.Enqueue(client, destination, asin);

        /// <summary>
        /// Returns a new instance of the <see cref="AmazonMetadataProvider" /> class if configured.
        /// </summary>
        /// <param name="configuration">The application configuration.</param>
        /// <returns>The <see cref="AmazonMetadataProvider" />.</returns>
        public static AmazonMetadataProvider GetInstance(IConfigurationRoot configuration)
        {
            var id = configuration["AWSAccessKeyId"] ?? Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
            var key = configuration["AWSSecretKey"] ?? Environment.GetEnvironmentVariable("AWS_SECRET_KEY");
            var tag = configuration["AmazonAssociateTag"] ?? Environment.GetEnvironmentVariable("AMAZON_ASSOCIATE_TAG");

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(key) || string.IsNullOrEmpty(tag))
            {
                return null;
            }
            return new AmazonMetadataProvider(id, key, tag);
        }
    }
}