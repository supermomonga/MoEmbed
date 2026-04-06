using MoEmbed.Providers;

using Portable.Xaml;

using System;
using System.IO;
using System.Text;

namespace MoEmbed.Models.Metadata
{
    public class UnknownMetadataTest
    {
        static UnknownMetadataTest()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        internal RequestContext GetRequestContext(Uri url)
        {
            var r = new RequestContext(new MetadataService(), new ConsumerRequest(url));
            r.Service.Providers.Add(new UnknownMetadataProvider());
            return r;
        }

        internal RequestContext GetRequestContext(string url)
        => GetRequestContext(new Uri(url));

        [Test]
        public async Task SerializationTest()
        {
            var url = "http://www.flickr.com/photos/bees/2341623661/";

            var rm = new UnknownMetadata()
            {
                Url = url.ToUri()
            };

            var d1 = await rm.FetchAsync(GetRequestContext(url));
            await Assert.That(d1).IsEqualTo(rm.Data);

            using (var sw = new StringWriter())
            {
                XamlServices.Save(sw, rm);

                var xml = sw.ToString();
                using (var sr = new StringReader(xml))
                {
                    var obj = XamlServices.Load(sr);
                    await Assert.That(obj).IsTypeOf<UnknownMetadata>();

                    var rm2 = (UnknownMetadata)obj;

                    await Assert.That(rm2.Data).IsNotNull();
                }
            }
        }

        [Test]
        // TODO: Removed due to HTTP 404 [Arguments("http://d.pr/i/sYDF7v.png", EmbedDataTypes.SingleImage)]
        [Arguments("http://imgur.com/GBfaPnJ.png", EmbedDataTypes.SingleImage)]
        [Arguments("https://www.springin.org/wp-content/uploads/2022/06/%E3%83%9E%E3%82%A6%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%83%E3%82%AF.mp3", EmbedDataTypes.SingleAudio)]
        [Arguments("https://gyazo.com/7dd82fe03e109f4a9db9074831b4c65b", EmbedDataTypes.MixedContent)]
        public async Task ResourceTypeTest(string url, EmbedDataTypes type)
        {
            var rm = new UnknownMetadata() { Url = url.ToUri() };
            var d = await rm.FetchAsync(GetRequestContext(url));
            await Assert.That(d.Type).IsEqualTo(type);
        }

        [Test]
        [Arguments("https://www.coins.tsukuba.ac.jp/~yas/coins/literacy-2012/2012-05-18/css-div-span.html", "スタイルシートでのDIVとSPANの利用法")]
        [Arguments("http://www.4gamer.net/games/383/G038390/20170610002/", "PC向け純百合ADV「ことのはアムリラート」，公式サイトが6月12日正午に公開")]
        [Arguments("http://www.sony.jp/vaio-v/?s_tc=jp_ml_rtm_vaijrny_170921_03&utm_medium=ml&utm_source=rtm&utm_campaign=170921", "VAIO（パーソナルコンピューター） | ソニー")]
        public async Task EncodingTest(string url, string title)
        {
            var rm = new UnknownMetadata() { Url = url.ToUri() };
            var d = await rm.FetchAsync(GetRequestContext(url));
            await Assert.That(d.Title).IsEqualTo(title);
        }

        [Test]
        [Arguments("https://rms.sexy", RestrictionPolicies.Unknown)]
        // TODO: https://developers.facebook.com/docs/graph-api/reference/open-graph-object-restrictions/
        // FIXME: Meta 社の Open Graph Object Restrictions 拡張を利用しているウェブサイトを探し、テストに追加する
        // [Arguments("https://www.dlsite.com/pro/work/=/product_id/VJ007039.html", RestrictionPolicies.Restricted)]
        public async Task RestrictionPolicyTest(string url, RestrictionPolicies policy)
        {
            var rm = new UnknownMetadata() { Url = url.ToUri() };
            var d = await rm.FetchAsync(GetRequestContext(url));
            await Assert.That(d.RestrictionPolicy).IsEqualTo(policy);
        }
    }
}
