using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Portable.Xaml;

namespace MoEmbed.Models.Metadata
{
    public class OEmbedProxyMetadataTest
    {
        [Test]
        public async Task SerializationTest()
        {
            var url = "http://www.flickr.com/photos/bees/2341623661/";
            var oEmbedUrl = "http://www.flickr.com/services/oembed/?format=json&url=http%3A//www.flickr.com/photos/bees/2341623661/";

            var rm = new OEmbedProxyMetadata()
            {
                Url = url,
                OEmbedUrl = oEmbedUrl
            };

            var d1 = await rm.FetchAsync(new RequestContext(new MetadataService(), new ConsumerRequest(new Uri(url))));
            await Assert.That(d1).IsEqualTo(rm.Data);

            using (var sw = new StringWriter())
            {
                XamlServices.Save(sw, rm);

                var xml = sw.ToString();
                using (var sr = new StringReader(xml))
                {
                    var obj = XamlServices.Load(sr);
                    await Assert.That(obj).IsTypeOf<OEmbedProxyMetadata>();

                    var rm2 = (OEmbedProxyMetadata)obj;

                    await Assert.That(rm2.Data).IsNotNull();
                }
            }
        }

        #region CreateEmbedData

        [Test]
        public async Task CreateEmbedDataTest_Title()
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var value = "hoge hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["title"] = value
            });

            await Assert.That(d.Title).IsEqualTo(value);
        }

        [Test]
        public async Task CreateEmbedDataTest_AuthorName()
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var value = "hoge hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["author_name"] = value
            });

            await Assert.That(d.AuthorName).IsEqualTo(value);
        }

        [Test]
        public async Task CreateEmbedDataTest_AuthorUrl()
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var value = "http://hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["author_url"] = value
            });

            await Assert.That(d.AuthorUrl).IsEqualTo(value);
        }

        [Test]
        public async Task CreateEmbedDataTest_ProviderName()
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var value = "hoge hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["provider_name"] = value
            });

            await Assert.That(d.ProviderName).IsEqualTo(value);
        }

        [Test]
        public async Task CreateEmbedDataTest_ProviderUrl()
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var value = "http://hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["provider_url"] = value
            });

            await Assert.That(d.ProviderUrl).IsEqualTo(value);
        }

        [Test]
        public async Task CreateEmbedDataTest_CacheAge()
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var value = "123";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["cache_age"] = value
            });

            await Assert.That(d.CacheAge).IsEqualTo(123);
        }

        [Test]
        public async Task CreateEmbedDataTest_Medias_Photo()
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["type"] = "photo",
                ["thumbnail_url"] = "http://thumb",
                ["thumbnail_width"] = 48,
                ["thumbnail_height"] = 32,
                ["url"] = "http://url",
                ["width"] = 480,
                ["height"] = 320,
            });

            await Assert.That(d.Type).IsEqualTo(EmbedDataTypes.SingleImage);
            await Assert.That(d.MetadataImage.Thumbnail.Url).IsEqualTo("http://url");
            await Assert.That(d.MetadataImage.Thumbnail.Width).IsEqualTo(480);
            await Assert.That(d.MetadataImage.Thumbnail.Height).IsEqualTo(320);
            await Assert.That(d.MetadataImage.RawUrl).IsEqualTo("http://url");
            await Assert.That(d.MetadataImage.Location).IsEqualTo("http://url");
            await Assert.That(d.Medias.Single()).IsEqualTo(d.MetadataImage);
        }

        [Test]
        public async Task CreateEmbedDataTest_Medias_Video()
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["type"] = "video",
                ["thumbnail_url"] = "http://thumb",
                ["thumbnail_width"] = 48,
                ["thumbnail_height"] = 32,
                ["url"] = "http://url",
                ["width"] = 480,
                ["height"] = 320,
            });

            await Assert.That(d.Type).IsEqualTo(EmbedDataTypes.SingleVideo);
            await Assert.That(d.MetadataImage.Thumbnail.Url).IsEqualTo("http://thumb");
            await Assert.That(d.MetadataImage.Thumbnail.Width).IsEqualTo(48);
            await Assert.That(d.MetadataImage.Thumbnail.Height).IsEqualTo(32);
            await Assert.That(d.MetadataImage.RawUrl).IsEqualTo("http://t");
            await Assert.That(d.MetadataImage.Location).IsEqualTo("http://t");
            await Assert.That(d.Medias.Single()).IsEqualTo(d.MetadataImage);
        }

        [Test]
        [Arguments("link")]
        [Arguments("rich")]
        [Arguments("hoge")]
        [Arguments(null)]
        public async Task CreateEmbedDataTest_Medias_Other(string type)
        {
            var t = new OEmbedProxyMetadata()
            {
                Url = "http://t"
            };
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["type"] = type,
                ["thumbnail_url"] = "http://thumb",
                ["thumbnail_width"] = 48,
                ["thumbnail_height"] = 32,
                ["url"] = "http://url",
                ["width"] = 480,
                ["height"] = 320,
            });

            await Assert.That(d.Type).IsEqualTo(EmbedDataTypes.MixedContent);
            await Assert.That(d.MetadataImage.Thumbnail.Url).IsEqualTo("http://thumb");
            await Assert.That(d.MetadataImage.Thumbnail.Width).IsEqualTo(48);
            await Assert.That(d.MetadataImage.Thumbnail.Height).IsEqualTo(32);
            await Assert.That(d.MetadataImage.RawUrl).IsNull();
            await Assert.That(d.MetadataImage.Location).IsNull();
            await Assert.That(d.Medias.Any()).IsFalse();
        }

        #endregion CreateEmbedData
    }
}
