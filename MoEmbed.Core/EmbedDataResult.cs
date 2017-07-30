using MoEmbed.Models;

namespace MoEmbed
{
    public class EmbedDataResult
    {
        public bool Succeeded { get; internal set; }
        public string ErrorMessage { get; internal set; }
        public IEmbedData Data { get; internal set; }
    }
}