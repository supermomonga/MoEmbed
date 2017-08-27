using System;
using System.Collections.Generic;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;
using Xunit;

namespace MoEmbed.Providers
{
    public class AmazonMetadataProviderTest
    {
        public static IEnumerable<object[]> GetMetadataTestData()
        {
            foreach (var p in new[] { null, "www." })
            {
                foreach (var d in new[] { "com", "com.br", "com.mx", "co.jp", "co.uk", "ca", "cn", "de", "es", "fr", "in", "it" })
                {
                    foreach (var asin in new[] { "B074FMRF3M" })
                    {
                        foreach (var url in new[] { $"https://{p}amazon.{d}/gp/product/{asin}", $"https://{p}amazon.{d}/dp/{asin}" })
                        {
                            yield return new object[] { url, asin };
                        }
                    }
                }
            }
        }

        [Theory]
        [MemberData(nameof(GetMetadataTestData))]
        public void GetMetadataTest(string url, string asin)
        {
            var m = Assert.IsType<AmazonMetadata>(new AmazonMetadataProvider(null, null, null).GetMetadata(new ConsumerRequest(new Uri(url))));
            Assert.Equal(asin, m.Asin);
        }
    }
}