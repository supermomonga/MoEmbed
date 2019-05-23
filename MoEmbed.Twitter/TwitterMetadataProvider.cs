using Microsoft.Extensions.Options;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;
using MoEmbed.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Tweetinvi.Logic.JsonConverters;
using Tweetinvi.Models;

namespace MoEmbed.Twitter
{
    public class TwitterMetadataProvider : IMetadataProvider
    {
        private readonly bool _IsEnabled;

        private class CustomJsonLanguageConverter : JsonLanguageConverter
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return reader.Value != null
                    ? base.ReadJson(reader, objectType, existingValue, serializer)
                    : Language.English;
            }
        }

        static TwitterMetadataProvider()
        {
            JsonPropertyConverterRepository.JsonConverters.Remove(typeof(Language));
            JsonPropertyConverterRepository.JsonConverters.Add(typeof(Language), new CustomJsonLanguageConverter());
        }

        public TwitterMetadataProvider(string consumerKey, string consumerSecret)
        {
            var credentials = Tweetinvi.Auth.SetApplicationOnlyCredentials(consumerKey, consumerSecret, true);
            Tweetinvi.Auth.SetCredentials(credentials);
            Tweetinvi.TweetinviConfig.CurrentThreadSettings.TweetMode = Tweetinvi.TweetMode.Extended;
            Tweetinvi.TweetinviConfig.ApplicationSettings.TweetMode = Tweetinvi.TweetMode.Extended;
            _IsEnabled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TwitterMetadataProvider" /> with the
        /// configuration for Twitter.
        /// </summary>
        /// <param name="optionsAccessor">The accessor to the configuration for Twitter.</param>
        public TwitterMetadataProvider(IOptions<TwitterMetadataOptions> optionsAccessor)
        {
            var consumerKey = optionsAccessor?.Value?.TwitterConsumerKey ?? Environment.GetEnvironmentVariable("TWITTER_CONSUMER_KEY");
            var consumerSecret = optionsAccessor?.Value?.TwitterConsumerSecret ?? Environment.GetEnvironmentVariable("TWITTER_CONSUMER_SECRET");
            if (!string.IsNullOrEmpty(consumerKey) && !string.IsNullOrEmpty(consumerSecret))
            {
                var credentials = Tweetinvi.Auth.SetApplicationOnlyCredentials(consumerKey, consumerSecret, true);
                Tweetinvi.Auth.SetCredentials(credentials);
                Tweetinvi.TweetinviConfig.CurrentThreadSettings.TweetMode = Tweetinvi.TweetMode.Extended;
                Tweetinvi.TweetinviConfig.ApplicationSettings.TweetMode = Tweetinvi.TweetMode.Extended;
                _IsEnabled = true;
            }
        }

        bool IMetadataProvider.SupportsAnyHost
            => false;

        bool IMetadataProvider.IsEnabled
            => _IsEnabled;

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
            return new TwitterMetadata()
            {
                Url = request.Url.ToString()
            };
        }
    }
}