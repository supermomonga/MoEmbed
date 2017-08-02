using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Portable.Xaml;
using Xunit;

namespace MoEmbed.Models
{
    public class UnknownMetadataTest
    {
        [Fact]
        public void SerializationTest()
        {
            var url = "http://www.flickr.com/photos/bees/2341623661/";

            var rm = new UnknownMetadata()
            {
                Uri = url
            };

            var d1 = rm.FetchAsync().GetAwaiter().GetResult();
            Assert.Equal(rm.Data, d1);

            using (var sw = new StringWriter())
            {
                XamlServices.Save(sw, rm);

                var xml = sw.ToString();
                using (var sr = new StringReader(xml))
                {
                    var obj = XamlServices.Load(sr);
                    Assert.IsType<UnknownMetadata>(obj);

                    var rm2 = (UnknownMetadata)obj;

                    Assert.NotNull(rm2.Data);

                    Assert.False(rm.Data.ToDictionary().Except(rm2.Data.ToDictionary()).Any());
                }
            }
        }
    }
}