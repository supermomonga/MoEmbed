using System;
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
    }
}