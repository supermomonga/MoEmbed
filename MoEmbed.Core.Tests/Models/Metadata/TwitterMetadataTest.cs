using MoEmbed.Providers;

using System;

namespace MoEmbed.Models.Metadata
{
    public class TwitterMetadataTest
    {
        [Test]
        [Arguments(
            463440424141459456L,
            "US Department of the Interior",
            "Sunsets don't get much better than this one over @GrandTetonNPS. #nature #sunset pic.twitter.com/YuKy2rcjyU"
            )]
        public async Task FetchAsyncTest(long tweetId, string expectedDisplayName, string expectedDescription)
        {
            var uri = $"https://twitter.com/Interior/status/{tweetId}";
            var target = new TwitterMetadataProvider().GetMetadata(
                new ConsumerRequest(new Uri(uri)));

            var data = await target.FetchAsync(
                            new RequestContext(
                                new MetadataService(),
                                new ConsumerRequest(new Uri(uri))));

            await Assert.That(data.Title).IsEqualTo(expectedDisplayName);
            await Assert.That(data.Description).IsEqualTo(expectedDescription);
        }
    }
}
