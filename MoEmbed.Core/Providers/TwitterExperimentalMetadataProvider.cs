using System.Collections.Generic;
using System.Text.RegularExpressions;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a twitter.com specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed class TwitterExperimentalMetadataProvider : IMetadataProvider
    {
        private const string GROUP_STATUS_ID = "statusId";
        // private static readonly Regex uriPattern = new(@$"^(https://twitter\.com/|https://twitter\.com/.*/status/(?<{GROUP_STATUS_ID}>\d+)|https://.*\.twitter\.com/.*/status/(?<{GROUP_STATUS_ID}>\d+))");
        private static readonly Regex uriPattern = new(@$"^(https://twitter\.com/.*/status/(?<{GROUP_STATUS_ID}>\d+)|https://.*\.twitter\.com/.*/status/(?<{GROUP_STATUS_ID}>\d+))");

        bool IMetadataProvider.SupportsAnyHost
            => false;

        bool IMetadataProvider.IsEnabled
            => true;

        /// <inheritdoc/>
        public bool CanHandle(ConsumerRequest request)
            => uriPattern.IsMatch(request.Url.ToString());

        /// <inheritdoc/>
        public Metadata GetMetadata(ConsumerRequest request)
        {
            var m = uriPattern.Match(request.Url.ToString());
            if (!m.Success)
            {
                return null;
            }
            return new TwitterExperimentalMetadata
            {
                Url = request.Url.ToString(),
                StatusId = m.Groups[GROUP_STATUS_ID].Value,
            };
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetSupportedHostNames()
        {
            yield return "twitter.com";
        }
    }
}