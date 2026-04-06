using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoEmbed.Models.Metadata
{
    public class MastodonMetadataTest
    {
        [Test]
        [Arguments("pawoo.net", 44073070L, "&nbsp;")]
        [Arguments("pawoo.net", 44074120L, "やるき\r\nげ ん き\r\nび  ょ  う  き")]
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

            await Assert.That(d.Description).IsEqualTo(expected);
        }
    }
}
