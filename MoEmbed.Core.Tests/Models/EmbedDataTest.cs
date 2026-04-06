using System.IO;
using Portable.Xaml;

namespace MoEmbed.Models
{
    public class EmbedDataTest
    {
        [Test]
        public async Task SerializationTest()
        {
            // TODO: Update Portable.Xaml
            var expected = new EmbedData()
            {
                // Description = "{NotBinding}",
                CacheAge = null,
                // AuthorName = "{}{Author}"
            };

            using (var sw = new StringWriter())
            {
                XamlServices.Save(sw, expected);

                var xml = sw.ToString();
                using (var sr = new StringReader(xml))
                {
                    var obj = XamlServices.Load(sr);
                    await Assert.That(obj).IsTypeOf<EmbedData>();

                    var actual = (EmbedData)obj;

                    await Assert.That(actual.Description).IsEqualTo(expected.Description);
                    await Assert.That(actual.CacheAge).IsEqualTo(expected.CacheAge);
                    await Assert.That(actual.AuthorName).IsEqualTo(expected.AuthorName);
                }
            }
        }
    }
}
