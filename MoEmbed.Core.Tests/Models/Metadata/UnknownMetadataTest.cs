﻿using MoEmbed.Providers;

using Portable.Xaml;

using System;
using System.IO;
using System.Text;

using Xunit;

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

        [Fact]
        public void SerializationTest()
        {
            var url = "http://www.flickr.com/photos/bees/2341623661/";

            var rm = new UnknownMetadata()
            {
                Url = url.ToUri()
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
        // TODO: Removed due to HTTP 404 [InlineData("http://d.pr/i/sYDF7v.png", EmbedDataTypes.SingleImage)]
        [InlineData("http://imgur.com/GBfaPnJ.png", EmbedDataTypes.SingleImage)]
        [InlineData("https://soundeffect-lab.info/sound/button/mp3/decision2.mp3", EmbedDataTypes.SingleAudio)]
        [InlineData("https://gyazo.com/7dd82fe03e109f4a9db9074831b4c65b", EmbedDataTypes.MixedContent)]
        public async void ResourceTypeTest(string url, EmbedDataTypes type)
        {
            var rm = new UnknownMetadata() { Url = url.ToUri() };
            var d = await rm.FetchAsync(GetRequestContext(url));
            Assert.Equal(type, d.Type);
        }

        [Theory]
        [InlineData("http://www.tbs.co.jp/baseball/top/main.html", "プロ野球速報")]
        [InlineData("http://www.4gamer.net/games/383/G038390/20170610002/", "PC向け純百合ADV「ことのはアムリラート」，公式サイトが6月12日正午に公開")]
        [InlineData("http://www.sony.jp/vaio-v/?s_tc=jp_ml_rtm_vaijrny_170921_03&utm_medium=ml&utm_source=rtm&utm_campaign=170921", "VAIO（パーソナルコンピューター） | ソニー | VAIO（パーソナルコンピューター） | ソニー")]
        public async void EncodingTest(string url, string title)
        {
            var rm = new UnknownMetadata() { Url = url.ToUri() };
            var d = await rm.FetchAsync(GetRequestContext(url));
            Assert.Equal(title, d.Title);
        }

        [Theory]
        [InlineData("https://rms.sexy", RestrictionPolicies.Unknown)]
        // TODO: https://developers.facebook.com/docs/graph-api/reference/open-graph-object-restrictions/
        // FIXME: Meta 社の Open Graph Object Restrictions 拡張を利用しているウェブサイトを探し、テストに追加する
        // [InlineData("https://www.dlsite.com/pro/work/=/product_id/VJ007039.html", RestrictionPolicies.Restricted)]
        public async void RestrictionPolicyTest(string url, RestrictionPolicies policy)
        {
            var rm = new UnknownMetadata() { Url = url.ToUri() };
            var d = await rm.FetchAsync(GetRequestContext(url));
            Assert.Equal(policy, d.RestrictionPolicy);
        }
    }
}