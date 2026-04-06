using System;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public sealed class NicovideoMetadataProviderTest
    {
        #region CanHandle

        [Test]
        [Arguments("http://www.nicovideo.jp/watch/sm43")]
        public async Task CanHandleTest_True(string uri)
            => await Assert.That(new NicovideoMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri)))).IsTrue();

        [Test]
        [Arguments("https://rms.sexy/")]
        public async Task CanHandleTest_False(string uri)
            => await Assert.That(new NicovideoMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri)))).IsFalse();

        #endregion CanHandle

        #region GetMetadata

        [Test]
        [Arguments("http://www.nicovideo.jp/watch/sm43", 43L)]
        public async Task GetMetadataTest_Success(string uri, long videoId)
        {
            var result = new NicovideoMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri)));
            await Assert.That(result).IsTypeOf<NicovideoMetadata>();
            var m = (NicovideoMetadata)result;

            await Assert.That(m.VideoId).IsEqualTo(videoId);
            await Assert.That(m.Data).IsNull();
        }

        [Test]
        [Arguments("https://rms.sexy/")]
        public async Task GetMetadataTest_Null(string uri)
            => await Assert.That(new NicovideoMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri)))).IsNull();

        #endregion GetMetadata
    }
}
