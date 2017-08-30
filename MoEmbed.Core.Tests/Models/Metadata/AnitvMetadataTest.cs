using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class AnitvMetadataTest
    {
        [Theory]
        [InlineData("https://ch.ani.tv/episodes/7552", "第4話 まいどぷり！みれぃやで！")]
        [InlineData("https://ch.ani.tv/episodes/6501", "ゆるゆり なちゅやちゅみ！+　+1")]
        public void LoadHtml_TitleTest(string url, string title)
        {
            var t = new AnitvMetadata() { Uri = url };
            var d = t.FetchAsync(new RequestContext(new MetadataService(), new ConsumerRequest(url.ToUri()))).GetAwaiter().GetResult();

            Assert.Equal(title, d.Title);
        }
    }
}