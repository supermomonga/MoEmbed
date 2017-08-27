using System;
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

        private string AWSAccessKeyId => Configuration["AWSAccessKeyId"] ?? Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
        private string AWSSecretKey => Configuration["AWSSecretKey"] ?? Environment.GetEnvironmentVariable("AWS_SECRET_KEY");
        private string AmazonAssociateTag => Configuration["AmazonAssociateTag"] ?? Environment.GetEnvironmentVariable("AMAZON_ASSOCIATE_TAG");

        [Theory]
        [InlineData("amazon.co.jp", "B074DYFZM7", "アイドルタイム プリパラ ファララマイク - Amazon.co.jp")]
        public void FetchAsyncTest(string destination, string asin, string title)
        {
            if (string.IsNullOrEmpty(AWSAccessKeyId))
            {
                return;
            }

            var md = new AmazonMetadata()
            {
                Provider = new AmazonMetadataProvider(AWSAccessKeyId, AWSSecretKey, AmazonAssociateTag),
                Destination = destination,
                Asin = asin
            };

            var d = md.FetchAsync(new RequestContext(new MetadataService(), new ConsumerRequest(null))).GetAwaiter().GetResult();

            Assert.Equal(title, d.Title);
        }
    }
}