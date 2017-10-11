using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a gyazo.com specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed class GyazoMetadataProvider : IMetadataProvider
    {
        private static readonly Regex regex = new Regex(@"^https://(gyazo.com/[0-9a-f]+|i\.gyazo.com/[0-9a-f]+\.(jpg|png|gif))$");

        bool IMetadataProvider.SupportsAnyHost
            => false;

        bool IMetadataProvider.IsEnabled
            => true;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
            => new[] { "gyazo.com", "i.gyazo.com" };

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
                if (request.Url.Host[0] == 'i')
                {
                    return new GyazoMetadata()
                    {
                        Url = new Uri("https://gyazo.com/" + Path.GetFileNameWithoutExtension(request.Url.AbsolutePath))
                    };
                }
                return new GyazoMetadata()
                {
                    Url = request.Url
                };
            }
            return null;
        }
    }
}