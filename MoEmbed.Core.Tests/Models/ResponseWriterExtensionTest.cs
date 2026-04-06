using System.IO;

namespace MoEmbed.Models
{
    public class ResponseWriterExtensionTest
    {
        #region WriteEmbedDataTest

        [Test]
        public async Task WriteEmbedDataTest_Json()
        {
            using (var ms = new MemoryStream())
            {
                await new JsonResponseWriter(ms).WriteEmbedDataAsync(new EmbedData());
            }
        }

        [Test]
        public async Task WriteEmbedDataTest_Xml()
        {
            using (var ms = new MemoryStream())
            {
                await new XmlResponseWriter(ms).WriteEmbedDataAsync(new EmbedData());
            }
        }

        #endregion WriteEmbedDataTest
    }
}
