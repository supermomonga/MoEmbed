using System;
using System.Text.RegularExpressions;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;
using Tweetinvi.Models;

namespace MoEmbed.Providers
{
    public class TwitterMetadataProvider : IMetadataProvider
    {
        private static Regex regex = new Regex(@"https:\/\/twitter\.com\/[^\/]+\/status\/(?<statusId>\d+)");

        private ITwitterCredentials Credentials { get; }

        public TwitterMetadataProvider(string consumerKey, string consumerSecret)
        {
            var credentials = Tweetinvi.Auth.SetApplicationOnlyCredentials(consumerKey, consumerSecret, true);
            Tweetinvi.Auth.SetCredentials(credentials);
        }

        public TwitterMetadataProvider(string consumerKey, string consumerSecret, string accessToken)
        {
            var credentials = Tweetinvi.Auth.SetApplicationOnlyCredentials(consumerKey, consumerSecret, accessToken);
            Tweetinvi.Auth.SetCredentials(credentials);
        }

        public bool CanHandle(Uri uri)
        {
            return regex.IsMatch(uri.ToString());
        }

        public bool CanHandle(ConsumerRequest request)
            => CanHandle(request.Url);


        public Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }
            return new TwitterMetadata(request.Url, this.Credentials);
        }
    }
}

