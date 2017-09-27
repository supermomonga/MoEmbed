using System;
using System.Threading.Tasks;
using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class MastodonMetadataTest
    {
        [Theory]
        [InlineData("pawoo.net", 44073070L, "&nbsp;")]
        [InlineData("pawoo.net", 44074120L, "‚â‚é‚«\r\n‚° ‚ñ ‚«\r\n‚Ñ  ‚å  ‚¤  ‚«")]
        public async Task DescriptionTest(string host, long id, string expected)
        {
            var d = await new MastodonMetadata()
            {
                Host = host,
                StatusId = id
            }.FetchAsync(new RequestContext(
                new MetadataService(),
                new ConsumerRequest(new Uri($"https://{host}/@u/{id}"))));
            Assert.Equal(expected, d.Description);
        }
    }
}