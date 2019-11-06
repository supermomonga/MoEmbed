using System.IO;
using Xunit;

namespace MoEmbed.Models
{
    public class ResponseWriterExtensionTest
    {
        #region WriteEmbedDataTest

        [Fact]
        public void WriteEmbedDataTest_Json()
        {
            using (var ms = new MemoryStream())
            {
                new JsonResponseWriter(ms).WriteEmbedDataAsync(new EmbedData());
            }
        }

        [Fact]
        public void WriteEmbedDataTest_Xml()
        {
            using (var ms = new MemoryStream())
            {
                new XmlResponseWriter(ms).WriteEmbedDataAsync(new EmbedData());
            }
        }

        #endregion WriteEmbedDataTest
    }
}