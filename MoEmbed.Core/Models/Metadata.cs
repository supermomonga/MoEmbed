using System.IO;
using System.Threading.Tasks;

namespace MoEmbed.Models
{
    // TODO: Move to Another file
    public enum Types { Photo, Video, Link, Rich }

    public abstract class Metadata
    { 
        public abstract Task<IEmbedData> FetchAsync();

        //public async Task WriteJsonAsync(Stream stream)
        //{
        //    using (var r = new JsonResponseWriter(stream, leaveOpen: true))
        //    {
        //        await WriteAsync(r);
        //    }
        //}

        //public Task WriteAsync(IResponseWriter writer)
        //{
        //    return Task.Run(() => Write(writer));
        //}

        //public void Write(IResponseWriter writer)
        //{
        //    writer.WriteStartResponse();
        //    WriteProperties(writer);
        //    writer.WriteEndResponse();
        //}

        //protected abstract void WriteProperties(IResponseWriter writer);

        //public override string ToString()
        //{
        //    using (var w = new StringWriter())
        //    using (var j = new JsonResponseWriter(w))
        //    {
        //        Write(j);
        //        return w.ToString();
        //    }
        //}
    }
}