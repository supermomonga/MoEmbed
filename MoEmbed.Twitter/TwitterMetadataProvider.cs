using System;
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