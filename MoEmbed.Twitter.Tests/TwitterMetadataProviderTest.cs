using System;
using Microsoft.Extensions.Configuration;
using MoEmbed.Models;
using Xunit;

namespace MoEmbed.Providers
{
    public sealed class TwitterMetadataProviderTest
    {
        internal IConfigurationRoot _Configuration;

        public IConfigurationRoot Configuration => _Configuration ??
            (_Configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<TwitterMetadataProviderTest>()
                .Build());

        internal MetadataService _Service;
        public MetadataService Service => _Service ?? (_Service = new MetadataService());

        public string ConsumerKey => Configuration["TwitterConsumerKey"] ?? Environment.GetEnvironmentVariable("TWITTER_CONSUMER_KEY");
        public string ConsumerSecret => Configuration["TwitterConsumerSecret"] ?? Environment.GetEnvironmentVariable("TWITTER_CONSUMER_SECRET");

        internal TwitterMetadataProvider _Provider;
        public TwitterMetadataProvider Provider => _Provider ?? (_Provider = new TwitterMetadataProvider(ConsumerKey, ConsumerSecret));

        public RequestContext GetRequestContext(Uri url)
        {
            var consumerRequest = new ConsumerRequest(url);
            return new RequestContext(Service, consumerRequest);
        }

        public RequestContext GetRequestContext(string url)
            => GetRequestContext(new Uri(url));

        #region CanHandle

        [Theory]
        [InlineData("https://twitter.com/mikoillust/status/887644409226866689")]
        [InlineData("https://mobile.twitter.com/mikoillust/status/887644409226866689")]
        public void CanHandleTest_True(string uri)
            => Assert.True(Provider.CanHandle(new ConsumerRequest(new Uri(uri))));

        #endregion CanHandle

        #region GetMetadata

        [Theory]
        [InlineData("https://twitter.com/Twitter/status/560070183650213889", 560070183650213889L, "Twitter")]
        [InlineData("https://mobile.twitter.com/Twitter/status/560070183650213889", 560070183650213889L, "Twitter")]
        public void GetMetadataTest_Success(string uri, long statusId, string screenName)
        {
            var m = Assert.IsType<TwitterMetadata>(Provider.GetMetadata(new ConsumerRequest(new Uri(uri))));

            Assert.Equal(statusId, m.TweetId);
            Assert.Equal(screenName, m.ScreenName);
            Assert.Null(m.Data);
        }

        [Theory]
        [InlineData("https://twitter.com/foo/status/560070183650213889", 560070183650213889L, "Twitter")]
        [InlineData("https://mobile.twitter.com/foo/status/560070183650213889", 560070183650213889L, "Twitter")]
        public async void GetMetadataTest_CorrectScreenName(string uri, long statusId, string screenName)
        {
            var m = Assert.IsType<TwitterMetadata>(Provider.GetMetadata(new ConsumerRequest(new Uri(uri))));

            await m.FetchAsync(GetRequestContext(uri));
            Assert.Equal(statusId, m.TweetId);
            Assert.Equal(screenName, m.ScreenName);
            Assert.NotNull(m.Data);
        }

        [Theory]
        [InlineData("https://rms.sexy/")]
        public void GetMetadataTest_Null(string uri)
            => Assert.Null(Provider.GetMetadata(new ConsumerRequest(new Uri(uri))));

        #endregion GetMetadata

        #region GetEmbedData

        [Theory]
        [InlineData("https://twitter.com/realDonaldTrump/status/900714982823821313", 0)]
        [InlineData("https://twitter.com/foo/status/560070183650213889", 1)]
        [InlineData("https://twitter.com/realDonaldTrump/status/900488148194516992", 4)]
        [InlineData("https://mobile.twitter.com/realDonaldTrump/status/900488148194516992", 4)]
        public async void GetEmbedDataTest_GetMedia(string uri, int mediaCount)
        {
            var m = Assert.IsType<TwitterMetadata>(Provider.GetMetadata(new ConsumerRequest(new Uri(uri))));

            await m.FetchAsync(GetRequestContext(uri));
            var data = m.Data;
            Assert.NotNull(m.Data);
            Assert.Equal(mediaCount, m.Data.Medias.Count);
        }

        [Theory]
        [InlineData("https://twitter.com/301kakugen/status/864532607916097536", "プリパラは好きぷり？ じゃあ大丈夫！できるぷり\n\n──南みれぃ")]
        [InlineData("https://mobile.twitter.com/4423s/status/901462528789626881", "")]
        [InlineData("https://twitter.com/EmmaKennedy/status/902886165350678529", "@realDonaldTrump You? Reading? IDON”TTHINKSO DonDon")]
        [InlineData("https://twitter.com/KiraTwins/status/903283834669604864", "🍽")]
        public async void GetEmbedDataTest_Description(string uri, string desription)
        {
            var m = Assert.IsType<TwitterMetadata>(Provider.GetMetadata(new ConsumerRequest(new Uri(uri))));

            await m.FetchAsync(GetRequestContext(uri));
            var data = m.Data;
            Assert.Equal(desription, data.Description);
        }

        [Theory]
        [InlineData("https://twitter.com/realDonaldTrump/status/900714982823821313", RestrictionPolicies.Unknown)]
        [InlineData("https://twitter.com/shift0808/status/900831119397986304", RestrictionPolicies.Restricted)]
        [InlineData("https://mobile.twitter.com/shift0808/status/900831119397986304", RestrictionPolicies.Restricted)]
        public async void GetEmbedDataTest_Nsfw(string uri, RestrictionPolicies policy)
        {
            var m = Assert.IsType<TwitterMetadata>(Provider.GetMetadata(new ConsumerRequest(new Uri(uri))));

            await m.FetchAsync(GetRequestContext(uri));
            var data = m.Data;
            Assert.Equal(policy, data.RestrictionPolicy);
        }

        #endregion GetEmbedData
    }
}