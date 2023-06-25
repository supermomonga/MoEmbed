using MoEmbed.Providers;

using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public async Task ImageResourceTypeTest(string url)
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

        [Theory]
        [InlineData("https://gyazo.com/b3c9e70fc041a500f3c8d83dd01bc614")]
        [InlineData("https://i.gyazo.com/b3c9e70fc041a500f3c8d83dd01bc614.gif")]
        public async Task VideoResourceTypeTest(string url)
        {
            var mp = new GyazoMetadataProvider();
            var rm = mp.GetMetadata(new ConsumerRequest(url.ToUri()));
            var d = await rm.FetchAsync(GetRequestContext(url));
            Assert.Equal(EmbedDataTypes.SingleVideo, d.Type);

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