using System;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public sealed class MisskeyMetadataProviderTest
    {
        #region CanHandle

        [Test]
        [Arguments("https://misskey.io/notes/akxj5hfgrr4u05dv")]
        [Arguments("https://misskey.io/notes/afuuqm0x9uze07zx")]
        [Arguments("https://misskey.io/notes/af3nbm1204mu03bl")]
        [Arguments("https://misskey.io/notes/af11iq63q0rr0d1c")]
        public async Task CanHandleTest_True(string uri)
            => await Assert.That(new MisskeyMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri)))).IsTrue();

        [Test]
        [Arguments("https://rms.sexy/")]
        [Arguments("https://example.com/notes/abc123")]
        [Arguments("http://misskey.io/notes/abc123")]
        [Arguments("https://misskey.io/users/abc123")]
        public async Task CanHandleTest_False(string uri)
            => await Assert.That(new MisskeyMetadataProvider().CanHandle(new ConsumerRequest(new Uri(uri)))).IsFalse();

        #endregion CanHandle

        #region GetMetadata

        [Test]
        [Arguments("https://misskey.io/notes/akxj5hfgrr4u05dv", "misskey.io", "akxj5hfgrr4u05dv")]
        [Arguments("https://misskey.io/notes/afuuqm0x9uze07zx", "misskey.io", "afuuqm0x9uze07zx")]
        public async Task GetMetadataTest_Success(string uri, string host, string noteId)
        {
            var result = new MisskeyMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri)));
            await Assert.That(result).IsTypeOf<MisskeyMetadata>();
            var m = (MisskeyMetadata)result;

            await Assert.That(m.Host).IsEqualTo(host);
            await Assert.That(m.NoteId).IsEqualTo(noteId);
            await Assert.That(m.Data).IsNull();
        }

        [Test]
        [Arguments("https://rms.sexy/")]
        [Arguments("https://example.com/notes/abc123")]
        public async Task GetMetadataTest_Null(string uri)
            => await Assert.That(new MisskeyMetadataProvider().GetMetadata(new ConsumerRequest(new Uri(uri)))).IsNull();

        #endregion GetMetadata
    }
}
