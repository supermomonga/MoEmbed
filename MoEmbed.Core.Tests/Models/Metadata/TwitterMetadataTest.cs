using MoEmbed.Providers;

using System;

using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class TwitterExperimentalMetadataTest
    {
        [Theory]
        [InlineData(
            463440424141459456L,
            "US Department of the Interior (@Interior)",
            "https://pbs.twimg.com/profile_images/432081479/DOI_LOGO_normal.jpg",
            "Sunsets don't get much better than this one over @GrandTetonNPS. #nature #sunset http://t.co/YuKy2rcjyU"
            )]
        public void FetchAsyncTest(long tweetId, string expectedDisplayName, string expectedProfileImageUrl, string expectedDescription)
        {
            var uri = $"https://twitter.com/Interior/status/{tweetId}";
            var target = new TwitterExperimentalMetadataProvider().GetMetadata(
                new ConsumerRequest(new Uri(uri)));

            var data = target.FetchAsync(
                            new RequestContext(
                                new MetadataService(),
                                new ConsumerRequest(new Uri(uri))))
                                .GetAwaiter().GetResult();

            Assert.Equal(expectedDisplayName, data.Title);
            Assert.Equal(expectedProfileImageUrl, data.MetadataImage.Thumbnail.Url);
            Assert.Equal(expectedDescription, data.Description);
        }

        [Theory]
        [InlineData(
            1608046425149177856L,
            "https://twitter.com/supermomonga/status/1608046425149177856/photo/1",
            "https://pbs.twimg.com/media/FlDtq9fakAIHeKj.jpg"
            )]
        public void SingleImageTest(long tweetId, string expectedLocation, string expectedRawUrl)
        {
            var uri = $"https://twitter.com/supermomonga/status/{tweetId}";
            var target = new TwitterExperimentalMetadataProvider().GetMetadata(
                new ConsumerRequest(new Uri(uri)));

            var data = target.FetchAsync(
                            new RequestContext(
                                new MetadataService(),
                                new ConsumerRequest(new Uri(uri))))
                                .GetAwaiter().GetResult();

            Assert.Equal(1, data.Medias.Count);
            Assert.Equal(expectedLocation, data.Medias[0].Location);
            Assert.Equal(expectedRawUrl, data.Medias[0].RawUrl);
        }
    }
}