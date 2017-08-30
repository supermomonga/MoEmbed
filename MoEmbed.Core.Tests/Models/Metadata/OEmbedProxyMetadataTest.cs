using System;
using System.Collections.Generic;
using System.IO;
using Portable.Xaml;
using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class OEmbedProxyMetadataTest
    {
        [Fact]
        public void SerializationTest()
        {
            var url = "http://www.flickr.com/photos/bees/2341623661/";
            var oEmbedUrl = "http://www.flickr.com/services/oembed/?format=json&url=http%3A//www.flickr.com/photos/bees/2341623661/";

            var rm = new OEmbedProxyMetadata()
            {
                Uri = url,
                OEmbedUrl = oEmbedUrl
            };

            var d1 = rm.FetchAsync(new RequestContext(new MetadataService(), new ConsumerRequest(new Uri(url)))).GetAwaiter().GetResult();
            Assert.Equal(rm.Data, d1);

            using (var sw = new StringWriter())
            {
                XamlServices.Save(sw, rm);

                var xml = sw.ToString();
                using (var sr = new StringReader(xml))
                {
                    var obj = XamlServices.Load(sr);
                    Assert.IsType<OEmbedProxyMetadata>(obj);

                    var rm2 = (OEmbedProxyMetadata)obj;

                    Assert.NotNull(rm2.Data);
                }
            }
        }

        #region CreateEmbedData

        [Fact]
        public void CreateEmbedDataTest_Title()
        {
            var t = new OEmbedProxyMetadata()
            {
                Uri = "http://t"
            };
            var value = "hoge hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["title"] = value
            });

            Assert.Equal(value, d.Title);
        }

        [Fact]
        public void CreateEmbedDataTest_AuthorName()
        {
            var t = new OEmbedProxyMetadata()
            {
                Uri = "http://t"
            };
            var value = "hoge hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["author_name"] = value
            });

            Assert.Equal(value, d.AuthorName);
        }

        [Fact]
        public void CreateEmbedDataTest_AuthorUrl()
        {
            var t = new OEmbedProxyMetadata()
            {
                Uri = "http://t"
            };
            var value = "http://hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["author_url"] = value
            });

            Assert.Equal(value.ToUri(), d.AuthorUrl);
        }

        [Fact]
        public void CreateEmbedDataTest_ProviderName()
        {
            var t = new OEmbedProxyMetadata()
            {
                Uri = "http://t"
            };
            var value = "hoge hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["provider_name"] = value
            });

            Assert.Equal(value, d.ProviderName);
        }

        [Fact]
        public void CreateEmbedDataTest_ProviderUrl()
        {
            var t = new OEmbedProxyMetadata()
            {
                Uri = "http://t"
            };
            var value = "http://hoge";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["provider_url"] = value
            });

            Assert.Equal(value.ToUri(), d.ProviderUrl);
        }

        [Fact]
        public void CreateEmbedDataTest_CacheAge()
        {
            var t = new OEmbedProxyMetadata()
            {
                Uri = "http://t"
            };
            var value = "123";
            var d = t.CreateEmbedData(new Dictionary<string, object>()
            {
                ["cache_age"] = value
            });

            Assert.Equal(123, d.CacheAge);
        }

        #endregion CreateEmbedData
    }
}