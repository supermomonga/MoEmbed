using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MoEmbed.Providers;
using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class GyazoMetadataTest
    {
        static GyazoMetadataTest()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        internal RequestContext GetRequestContext(Uri url)
        {
            var r = new RequestContext(new MetadataService(), new ConsumerRequest(url));
            r.Service.Providers.Add(new GyazoMetadataProvider());
            return r;
        }

        internal RequestContext GetRequestContext(string url)
        => GetRequestContext(new Uri(url));

        [Theory]
        [InlineData("https://gyazo.com/7dd82fe03e109f4a9db9074831b4c65b")]
        [InlineData("https://i.gyazo.com/7dd82fe03e109f4a9db9074831b4c65b.jpg")]
        [InlineData("https://gyazo.com/b3c9e70fc041a500f3c8d83dd01bc614")]
        [InlineData("https://i.gyazo.com/cd81056cb568d7a6d51b8ff87e51efa0.png")]
        public async Task ResourceTypeTest(string url)
        {
            var rm = new GyazoMetadata() { Url = url.ToUri() };
            var d = await rm.FetchAsync(GetRequestContext(url));
            Assert.Equal(EmbedDataTypes.SingleImage, d.Type);

            using (var hc = new HttpClient())
            {
                foreach (var m in d.Medias)
                {
                    if (m.RawUrl != null)
                    {
                        var rr = await hc.SendAsync(new HttpRequestMessage(HttpMethod.Head, m.RawUrl));
                        rr.EnsureSuccessStatusCode();
                    }

                    if (m.Thumbnail != null)
                    {
                        var tr = await hc.SendAsync(new HttpRequestMessage(HttpMethod.Head, m.Thumbnail.Url));
                        tr.EnsureSuccessStatusCode();
                    }
                }
            }
        }
    }
}