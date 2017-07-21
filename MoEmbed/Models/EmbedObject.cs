using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoEmbed.Models
{
    public enum Types { Photo, Video, Link, Rich }

    abstract class EmbedObject
    {
        // See spec: http://oembed.com/#section2

        public abstract Types Type { get; }

        protected virtual string TypeString
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

        #region optional properties

        [DefaultValue(null)]
        public virtual string Title { get; set; }
        
        [DefaultValue(null)]
        public virtual string AuthorName { get; set; }
                
        [DefaultValue(null)]
        public virtual Uri AuthorUrl { get; set; }
                
        [DefaultValue(null)]
        public virtual string ProviderName { get; set; }
                
        [DefaultValue(null)]
        public virtual Uri ProviderUrl { get; set; }
                
        [DefaultValue(null)]
        public virtual int? CacheAge { get; set; }
                
        [DefaultValue(null)]
        public virtual Uri ThumbnailUrl { get; set; }
                
        [DefaultValue(null)]
        public virtual int? ThumbnailWidth { get; set; }
        
        [DefaultValue(null)]
        public virtual int? ThumbnailHeight { get; set; }
        
        #endregion optional properties

        public abstract Task FetchAsync();

        public async Task WriteJsonAsync(Stream stream)
        {
            using(var r = new JsonResponseWriter(stream, leaveOpen: true))
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

        protected virtual void WriteProperties(IResponseWriter writer)
        {
            writer.WriteProperty("type", TypeString);
            writer.WriteProperty("version", Version);
            writer.WritePropertyIfNeeded("title", Title);
            writer.WritePropertyIfNeeded("author_name", AuthorName);
            writer.WritePropertyIfNeeded("author_url", AuthorUrl);
            writer.WritePropertyIfNeeded("provider_name", ProviderName);
            writer.WritePropertyIfNeeded("provider_url", ProviderUrl);
            writer.WritePropertyIfNeeded("cache_age", CacheAge);
            writer.WritePropertyIfNeeded("thumbnail_url", ThumbnailUrl);
            writer.WritePropertyIfNeeded("thumbnail_width", ThumbnailWidth);
            writer.WritePropertyIfNeeded("thumbnail_height", ThumbnailHeight);
        }

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

