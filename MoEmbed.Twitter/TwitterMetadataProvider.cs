using System;
using System.Collections.Generic;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public class TwitterMetadataProvider : IMetadataProvider
    {
        public TwitterMetadataProvider(string consumerKey, string consumerSecret)
        {
            var credentials = Tweetinvi.Auth.SetApplicationOnlyCredentials(consumerKey, consumerSecret, true);
            Tweetinvi.Auth.SetCredentials(credentials);
            Tweetinvi.TweetinviConfig.CurrentThreadSettings.TweetMode = Tweetinvi.TweetMode.Extended;
            Tweetinvi.TweetinviConfig.ApplicationSettings.TweetMode = Tweetinvi.TweetMode.Extended;
        }

        bool IMetadataProvider.SupportsAnyHost
            => false;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public IEnumerable<string> GetSupportedHostNames()
            => new[] { "twitter.com", "mobile.twitter.com" };

        public bool CanHandle(Uri uri)
            => TwitterMetadata.regex.IsMatch(uri.ToString());

        public bool CanHandle(ConsumerRequest request)
            => CanHandle(request.Url);

        public Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }
            return new TwitterMetadata(request.Url);
        }
    }
}