using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a twitter.com specifiec metadata for the specified consumer request.
    /// </summary>
    public sealed partial class TwitterMetadataProvider : IMetadataProvider
    {

        bool IMetadataProvider.SupportsAnyHost
            => false;

        bool IMetadataProvider.IsEnabled
            => true;

        /// <inheritdoc/>
        public new Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }
            var m = new TwitterMetadata
            {
                Url = request.Url.ToString(),
                OEmbedUrl = GetProviderUriFor(request).ToString()
            };

            return m;
        }
    }
}