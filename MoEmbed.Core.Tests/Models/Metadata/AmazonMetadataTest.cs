using Microsoft.Extensions.Configuration;
using MoEmbed.Providers;

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

        [Test]
        [Arguments("amazon.co.jp", "B074DYFZM7", "アイドルタイム プリパラ ファララマイク - Amazon.co.jp")]
        public async Task FetchAsyncTest(string destination, string asin, string title)
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

            var d = await md.FetchAsync(new RequestContext(new MetadataService(), new ConsumerRequest(null)));

            await Assert.That(d.Title).IsEqualTo(title);
        }
    }
}
