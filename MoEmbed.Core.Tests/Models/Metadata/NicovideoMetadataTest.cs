using System;
using System.IO;
using Portable.Xaml;
using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class NicovideoMetadataTest
    {
        [Fact]
        public void SerializationTest()
        {
            var expected = new NicovideoMetadata()
            {
                VideoId = int.MaxValue + 1L,
                Data = new EmbedData()
                {
                    Title = "hoge"
                }
            };

            using (var sw = new StringWriter())
            {
                XamlServices.Save(sw, expected);

                var xml = sw.ToString();
                using (var sr = new StringReader(xml))
                {
                    var obj = XamlServices.Load(sr);
                    Assert.IsType<NicovideoMetadata>(obj);

                    var actual = (NicovideoMetadata)obj;

                    Assert.Equal(expected.VideoId, actual.VideoId);
                    Assert.Equal(expected.Data.Title, actual.Data.Title);
                }
            }
        }

        [Theory]
        [InlineData(28278558L, "【プリパラ】「ぷりっとぱ～ふぇくと」をぬるぬるにしてみた【HD60fps】")]
        public void FetchAsyncTest(long videoId, string expectedTitle)
        {
            var target = new NicovideoMetadata()
            {
                VideoId = videoId
            };

            var data = target.FetchAsync(
                            new RequestContext(
                                new MetadataService(),
                                new ConsumerRequest(new Uri("http://www.nicovideo.jp/watch/sm" + videoId))))
                                .GetAwaiter().GetResult();

            Assert.Equal(expectedTitle, data.Title);
        }
    }
}