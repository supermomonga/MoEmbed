using System;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;
using Xunit;

namespace MoEmbed.Providers
{
    public sealed class NicovideoMetadataProviderTest
    {
        #region CanHandle

        [Theory]
        [InlineData("http://www.nicovideo.jp/watch/sm43")]
        public void CanHandleTest_True(string uri)
            => Assert.True(new NicovideoMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri))));

        [Theory]
        [InlineData("https://rms.sexy/")]
        public void CanHandleTest_False(string uri)
            => Assert.False(new NicovideoMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri))));

        #endregion CanHandle

        #region GetMetadata

        [Theory]
        [InlineData("http://www.nicovideo.jp/watch/sm43", 43L)]
        public void GetMetadataTest_Success(string uri, long videoId)
        {
            var m = Assert.IsType<NicovideoMetadata>(new NicovideoMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri))));

            Assert.Equal(videoId, m.VideoId);
            Assert.Null(m.Data);
        }

        [Theory]
        [InlineData("https://rms.sexy/")]
        public void GetMetadataTest_Null(string uri)
            => Assert.Null(new NicovideoMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri))));

        #endregion GetMetadata
    }
}