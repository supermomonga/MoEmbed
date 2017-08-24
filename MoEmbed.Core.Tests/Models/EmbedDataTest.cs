using System.IO;
using Portable.Xaml;
using Xunit;

namespace MoEmbed.Models
{
    public class EmbedDataTest
    {
        [Fact]
        public void SerializationTest()
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
                    Assert.IsType<EmbedData>(obj);

                    var actual = (EmbedData)obj;

                    Assert.Equal(expected.Description, actual.Description);
                    Assert.Equal(expected.CacheAge, actual.CacheAge);
                    Assert.Equal(expected.AuthorName, actual.AuthorName);
                }
            }
        }
    }
}