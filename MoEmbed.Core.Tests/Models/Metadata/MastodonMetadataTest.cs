using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace MoEmbed.Models.Metadata
{
    public class MastodonMetadataTest
    {
        [Theory]
        [InlineData("pawoo.net", 44073070L, "&nbsp;")]
        [InlineData("pawoo.net", 44074120L, "やるき\r\nげ ん き\r\nび  ょ  う  き")]
        public async Task DescriptionTest(string host, long id, string expected)
        {
            var d = await new MastodonMetadata()
            {
                Host = host,
                StatusId = id
            }.FetchAsync(new RequestContext(
                new MetadataService(),
                new ConsumerRequest(new Uri($"https://{host}/@u/{id}"))));

            expected = Regex.Replace(expected, @"\r\n", Environment.NewLine);

            Assert.Equal(expected, d.Description);
        }
    }
}