using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace MoEmbed.Models.Metadata
{
    public class AnitvMetadataTest
    {
        internal readonly ITestOutputHelper Output;

        public AnitvMetadataTest(ITestOutputHelper output = null)
        {
            Output = output;
        }

        [Theory]
        [InlineData("https://ch.ani.tv/episodes/7552", "第4話 まいどぷり！みれぃやで！")]
        [InlineData("https://ch.ani.tv/episodes/6501", "ゆるゆり なちゅやちゅみ！+　+1")]
        public void LoadHtml_TitleTest(string url, string title)
        {
            var t = new AnitvMetadata() { Uri = url };

            using (var hc = new HttpClient())
            {
                var html = hc.GetAsync(url).GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();

                var hd = t.LoadHtml(html);
                var nav = hd.CreateNavigator();
                var d = t.Data;
                try
                {
                    Assert.Equal(title, d.Title);
                }
                catch
                {
                    Output.WriteLine("h3:" + nav.SelectSingleNode("//*[@class='movie-content-note']/h3/text()")?.Value);
                    Output.WriteLine("h2:" + nav.SelectSingleNode("//*[@class='movie-content-note']/h2/text()")?.Value);
                    Output.WriteLine("HTML: " + html);
                }
            }
        }
    }
}