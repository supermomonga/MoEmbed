using Portable.Xaml;

using System;
using System.IO;

namespace MoEmbed.Models.Metadata
{
    public class NicovideoMetadataTest
    {
        [Test]
        public async Task SerializationTest()
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
                    await Assert.That(obj).IsTypeOf<NicovideoMetadata>();

                    var actual = (NicovideoMetadata)obj;

                    await Assert.That(actual.VideoId).IsEqualTo(expected.VideoId);
                    await Assert.That(actual.Data.Title).IsEqualTo(expected.Data.Title);
                }
            }
        }

        [Test]
        [Arguments(41303991L, "第49回！これって何ナンバーカード？【ソフトウェアトーク劇場】")]
        public async Task FetchAsyncTest(long videoId, string expectedTitle)
        {
            var target = new NicovideoMetadata()
            {
                VideoId = videoId
            };

            var data = await target.FetchAsync(
                            new RequestContext(
                                new MetadataService(),
                                new ConsumerRequest(new Uri("http://www.nicovideo.jp/watch/sm" + videoId))));

            await Assert.That(data.Title).IsEqualTo(expectedTitle);
        }
    }
}
