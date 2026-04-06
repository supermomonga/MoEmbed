using System;
using System.Collections.Generic;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public class AmazonMetadataProviderTest
    {
        public static IEnumerable<(string url, string asin)> GetMetadataTestData()
        {
            foreach (var p in new[] { null, "www." })
            {
                foreach (var d in new[] { "com", "com.br", "com.mx", "co.jp", "co.uk", "ca", "cn", "de", "es", "fr", "in", "it" })
                {
                    foreach (var asin in new[] { "B074FMRF3M" })
                    {
                        foreach (var url in new[] { $"https://{p}amazon.{d}/gp/product/{asin}", $"https://{p}amazon.{d}/dp/{asin}" })
                        {
                            yield return (url, asin);
                        }
                    }
                }
            }
        }

        [Test]
        [MethodDataSource(nameof(GetMetadataTestData))]
        public async Task GetMetadataTest(string url, string asin)
        {
            var result = new AmazonMetadataProvider(null, null, null).GetMetadata(new ConsumerRequest(new Uri(url)));
            await Assert.That(result).IsTypeOf<AmazonMetadata>();
            var m = (AmazonMetadata)result;
            await Assert.That(m.Asin).IsEqualTo(asin);
        }
    }
}
