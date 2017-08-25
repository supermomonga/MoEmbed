using System;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;
using Xunit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace MoEmbed.Providers
{
    public sealed class TwitterMetadataProviderTest
    {
        internal IConfigurationRoot _Configuration;
        public IConfigurationRoot Configuration => _Configuration ??
            ( _Configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<TwitterMetadataProviderTest>()
                .Build());

        public string ConsumerKey => Configuration["TwitterConsumerKey"] ?? Environment.GetEnvironmentVariable("TWITTER_CONSUMER_KEY");
        public string ConsumerSecret => Configuration["TwitterConsumerSecret"] ?? Environment.GetEnvironmentVariable("TWITTER_CONSUMER_SECRET");

        internal TwitterMetadataProvider _Provider;
        public TwitterMetadataProvider Provider => _Provider ?? ( _Provider = new TwitterMetadataProvider(ConsumerKey, ConsumerSecret) );

        #region CanHandle

        [Theory]
        [InlineData("https://twitter.com/mikoillust/status/887644409226866689")]
        public void CanHandleTest_True(string uri)
            => Assert.True(Provider.CanHandle(new ConsumerRequest(new Uri(uri))));

        #endregion CanHandle

        #region GetMetadata

        [Theory]
        [InlineData("https://twitter.com/Twitter/status/560070183650213889", 560070183650213889L, "Twitter")]
        public void GetMetadataTest_Success(string uri, long statusId, string screenName)
        {
            var m = Assert.IsType<TwitterMetadata>(Provider.GetMetadata(new ConsumerRequest(new Uri(uri))));

            Assert.Equal(statusId, m.TweetId);
            Assert.Equal(screenName, m.ScreenName);
            Assert.Null(m.Data);
        }

        [Theory]
        [InlineData("https://rms.sexy/")]
        public void GetMetadataTest_Null(string uri)
            => Assert.Null(Provider.GetMetadata(new ConsumerRequest(new Uri(uri))));

        #endregion GetMetadata
    }
}







