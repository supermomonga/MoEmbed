using MoEmbed.Models;
using MoEmbed.Models.Metadata;

using System;

using Xunit;

namespace MoEmbed.Providers
{
    public sealed class TwitterMetadataProviderTest
    {
        #region CanHandle

        [Theory]
        [InlineData("https://twitter.com/Interior/status/463440424141459456")]
        public void CanHandleTest_True(string uri)
            => Assert.True(new TwitterMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri))));

        [Theory]
        [InlineData("https://rms.sexy/")]
        public void CanHandleTest_False(string uri)
            => Assert.False(new TwitterMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri))));

        #endregion CanHandle

        #region GetMetadata

        [Theory]
        [InlineData("https://twitter.com/Interior/status/463440424141459456")]
        public void GetMetadataTest_Success(string uri)
        {
            var m = Assert.IsType<TwitterMetadata>(
                new TwitterMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri))));
            Assert.Equal(uri, m.Url);
            Assert.Null(m.Data);
        }

        [Theory]
        [InlineData("https://rms.sexy/")]
        public void GetMetadataTest_Null(string uri)
            => Assert.Null(new TwitterMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri))));

        #endregion GetMetadata
    }
}