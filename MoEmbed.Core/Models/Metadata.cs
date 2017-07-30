using System.IO;
using System.Threading.Tasks;

namespace MoEmbed.Models
{
    // TODO: Move to Another file
    public enum Types { Photo, Video, Link, Rich }

    public abstract class Metadata
    {
        // See spec: http://oembed.com/#section2

        public abstract Types Type { get; }

        protected string TypeString
        {
            get
            {
                switch (Type)
                {
                    case Types.Photo: return "photo";
                    case Types.Link: return "link";
                    case Types.Video: return "video";
                    case Types.Rich: return "rich";
                    default: return Type.ToString();
                }
            }
        }

        // Version is fixed.
        public virtual string Version => "1.0";

        public abstract Task FetchAsync();

        public async Task WriteJsonAsync(Stream stream)
        {
            using (var r = new JsonResponseWriter(stream, leaveOpen: true))
            {
                await WriteAsync(r);
            }
        }

        public Task WriteAsync(IResponseWriter writer)
        {
            return Task.Run(() => Write(writer));
        }

        public void Write(IResponseWriter writer)
        {
            writer.WriteStartResponse();
            WriteProperties(writer);
            writer.WriteEndResponse();
        }

        protected abstract void WriteProperties(IResponseWriter writer);

        public override string ToString()
        {
            using (var w = new StringWriter())
            using (var j = new JsonResponseWriter(w))
            {
                Write(j);
                return w.ToString();
            }
        }
    }
}