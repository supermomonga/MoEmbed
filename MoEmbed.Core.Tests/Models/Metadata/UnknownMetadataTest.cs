using System;
using System.IO;
using MoEmbed.Providers;
using Portable.Xaml;
using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class UnknownMetadataTest
    {
        internal RequestContext GetRequestContext(Uri url)
        {
            var r = new RequestContext(new MetadataService(), new ConsumerRequest(url));
            r.Service.Providers.Add(new UnknownMetadataProvider());
            return r;
        }

        internal RequestContext GetRequestContext(string url)
        => GetRequestContext(new Uri(url));

        [Fact]
        public void SerializationTest()
        {
            var url = "http://www.flickr.com/photos/bees/2341623661/";

            var rm = new UnknownMetadata()
            {
                Uri = url
            };

            var d1 = rm.FetchAsync(GetRequestContext(url)).GetAwaiter().GetResult();
            Assert.Equal(rm.Data, d1);

            using (var sw = new StringWriter())
            {
                XamlServices.Save(sw, rm);

                var xml = sw.ToString();
                using (var sr = new StringReader(xml))
                {
                    var obj = XamlServices.Load(sr);
                    Assert.IsType<UnknownMetadata>(obj);

                    var rm2 = (UnknownMetadata)obj;

                    Assert.NotNull(rm2.Data);
                }
            }
        }

        [Theory]
        [InlineData("http://d.pr/i/sYDF7v.png", EmbedDataTypes.SingleImage)]
        [InlineData("http://imgur.com/GBfaPnJ.png", EmbedDataTypes.SingleImage)]
        [InlineData("http://game-a5.granbluefantasy.jp/assets/sound/voice/3030147000_v_017.mp3", EmbedDataTypes.SingleAudio)]
        [InlineData("https://gyazo.com/7dd82fe03e109f4a9db9074831b4c65b", EmbedDataTypes.MixedContent)]
        public async void ResourceTypeTest(string url, EmbedDataTypes type)
        {
            var rm = new UnknownMetadata() { Uri = url };
            var d = await rm.FetchAsync(GetRequestContext(url));
            Assert.Equal(type, d.Type);
        }
    }
}

