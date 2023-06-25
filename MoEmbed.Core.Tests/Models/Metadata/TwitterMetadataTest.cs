using MoEmbed.Providers;

using System;

using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class TwitterMetadataTest
    {
        [Theory]
        [InlineData(
            463440424141459456L,
            "US Department of the Interior",
            "Sunsets don't get much better than this one over @GrandTetonNPS. #nature #sunset pic.twitter.com/YuKy2rcjyU"
            )]
        public void FetchAsyncTest(long tweetId, string expectedDisplayName, string expectedDescription)
        {
            var uri = $"https://twitter.com/Interior/status/{tweetId}";
            var target = new TwitterMetadataProvider().GetMetadata(
                new ConsumerRequest(new Uri(uri)));

            var data = target.FetchAsync(
                            new RequestContext(
                                new MetadataService(),
                                new ConsumerRequest(new Uri(uri))))
                                .GetAwaiter().GetResult();

            Assert.Equal(expectedDisplayName, data.Title);
            Assert.Equal(expectedDescription, data.Description);
        }
    }
}