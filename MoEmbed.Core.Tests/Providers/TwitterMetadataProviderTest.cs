using MoEmbed.Models;
using MoEmbed.Models.Metadata;

using System;

namespace MoEmbed.Providers
{
    public sealed class TwitterMetadataProviderTest
    {
        #region CanHandle

        [Test]
        [Arguments("https://twitter.com/Interior/status/463440424141459456")]
        public async Task CanHandleTest_True(string uri)
            => await Assert.That(new TwitterMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri)))).IsTrue();

        [Test]
        [Arguments("https://rms.sexy/")]
        public async Task CanHandleTest_False(string uri)
            => await Assert.That(new TwitterMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri)))).IsFalse();

        #endregion CanHandle

        #region GetMetadata

        [Test]
        [Arguments("https://twitter.com/Interior/status/463440424141459456")]
        public async Task GetMetadataTest_Success(string uri)
        {
            var result = new TwitterMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri)));
            await Assert.That(result).IsTypeOf<TwitterMetadata>();
            var m = (TwitterMetadata)result;
            await Assert.That(m.Url).IsEqualTo(uri);
            await Assert.That(m.Data).IsNull();
        }

        [Test]
        [Arguments("https://rms.sexy/")]
        public async Task GetMetadataTest_Null(string uri)
            => await Assert.That(new TwitterMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri)))).IsNull();

        #endregion GetMetadata
    }
}
