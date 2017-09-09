using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MoEmbed.Models;
using MoEmbed.Models.Imgur;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Represents the <see cref="Metadata" /> for the URL of the imgur.com
    /// </summary>
    public sealed class ImgurMetadataProvider : IMetadataProvider
    {
        private static readonly Regex regex = new Regex(@"^https?://(i\.)?imgur\.com(?<t>/a|/gallery)?/(?<h>[a-zA-Z0-9]+)$");

        public ImgurMetadataProvider(IOptions<ImgurMetadataOptions> optionsAccessor)
        {
            var id = optionsAccessor?.Value?.ImgurClientId
                    ?? Environment.GetEnvironmentVariable("IMGUR_CLIENT_ID");

            ClientId = id;
        }

        bool IMetadataProvider.SupportsAnyHost
            => false;

        bool IMetadataProvider.IsEnabled
            => true;

        /// <summary>
        /// Gets or sets the imgur.com OAUth client id.
        /// </summary>
        public string ClientId { get; set; }

        internal DateTime LastFaulted { get; set; }

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
            => new[] { "imgur.com" };

        /// <inheritdoc />
        public bool CanHandle(ConsumerRequest request)
            => regex.IsMatch(request.Url.ToString());

        /// <inheritdoc />
        public Metadata GetMetadata(ConsumerRequest request)
        {
            var m = regex.Match(request.Url.ToString());

            if (m.Success)
            {
                var t = m.Groups["t"];
                return new ImgurMetadata()
                {
                    Provider = this,
                    Url = request.Url,
                    Type = !t.Success ? ImgurType.Image
                            : t.Value == "/a" ? ImgurType.Album
                            : ImgurType.Gallery,
                    Hash = m.Groups["h"].Value
                };
            }

            return null;
        }

        internal static bool ParseUrl(ImgurMetadata metadata)
        {
            if (metadata?.Url != null)
            {
                var m = regex.Match(metadata.Url.ToString());

                if (m.Success)
                {
                    var t = m.Groups["t"];

                    metadata.Type = !t.Success ? ImgurType.Image
                                        : t.Value == "a" ? ImgurType.Album
                                        : ImgurType.Gallery;
                    metadata.Hash = m.Groups["h"].Value;

                    return true;
                }
            }
            return false;
        }
    }
}