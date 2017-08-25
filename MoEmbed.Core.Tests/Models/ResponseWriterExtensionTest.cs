using System.IO;
using MoEmbed.Models.OEmbed;
using Xunit;

namespace MoEmbed.Models
{
    public class ResponseWriterExtensionTest
    {
        #region WriteOEmbedTest

        [Theory]
        [InlineData(Types.Link)]
        [InlineData(Types.Photo)]
        [InlineData(Types.Rich)]
        [InlineData(Types.Video)]
        public void WriteOEmbedTest_Json(Types type)
        {
            using (var ms = new MemoryStream())
            {
                new JsonResponseWriter(ms).WriteOEmbed(new OEmbedData() { Type = type });
            }
        }

        [Theory]
        [InlineData(Types.Link)]
        [InlineData(Types.Photo)]
        [InlineData(Types.Rich)]
        [InlineData(Types.Video)]
        public void WriteOEmbedTest_Xml(Types type)
        {
            using (var ms = new MemoryStream())
            {
                new XmlResponseWriter(ms).WriteOEmbed(new OEmbedData() { Type = type });
            }
        }

        #endregion WriteOEmbedTest

        #region WriteEmbedDataTest

        [Fact]
        public void WriteEmbedDataTest_Json()
        {
            using (var ms = new MemoryStream())
            {
                new JsonResponseWriter(ms).WriteEmbedData(new EmbedData());
            }
        }

        [Fact]
        public void WriteEmbedDataTest_Xml()
        {
            using (var ms = new MemoryStream())
            {
                new XmlResponseWriter(ms).WriteEmbedData(new EmbedData());
            }
        }

        #endregion WriteEmbedDataTest
    }
}