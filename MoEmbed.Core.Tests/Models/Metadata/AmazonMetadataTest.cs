using Microsoft.Extensions.Configuration;
using MoEmbed.Providers;
using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class AmazonMetadataTest
    {
        private IConfigurationRoot _Configuration;

        public IConfigurationRoot Configuration => _Configuration ??
            (_Configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddUserSecrets<AmazonMetadataTest>()
                .Build());

        [Theory]
        [InlineData("amazon.co.jp", "B074DYFZM7", "アイドルタイム プリパラ ファララマイク - Amazon.co.jp")]
        public void FetchAsyncTest(string destination, string asin, string title)
        {
            var prov = AmazonMetadataProvider.GetInstance(Configuration);
            if (prov == null)
            {
                return;
            }

            var md = new AmazonMetadata()
            {
                Provider = prov,
                Destination = destination,
                Asin = asin
            };

            var d = md.FetchAsync(new RequestContext(new MetadataService(), new ConsumerRequest(null))).GetAwaiter().GetResult();

            Assert.Equal(title, d.Title);
        }
    }
}