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

        [JsonIgnore]
        public Types Type { get; }

        [JsonProperty("type")]
        public string TypeString
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
        [JsonProperty]
        public static string Version => "1.0";

        public string Title { get; set; }

        // Below is optional properties
        public string AuthorName { get; set; }

        private JsonSerializer _JsonSerializer;
        protected JsonSerializer JsonSerializer
        {
            get
            {
                if (this._JsonSerializer == null)
                {
                    this._JsonSerializer = new JsonSerializer();
                    this._JsonSerializer.ContractResolver = new DefaultContractResolver()
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                }
                return this._JsonSerializer;
            }
        }

        public EmbedObject(Types type)
        {
            this.Type = type;
        }

        public abstract Task FetchAsync();

        public Task WriteAsync(Stream stream)
        {
            var streamWriter = new StreamWriter(stream);
            return this.WriteAsync(streamWriter);
        }

        public Task WriteAsync(TextWriter textWriter)
        {
            return Task.Run(() => Write(textWriter));
        }

        public void Write(TextWriter textWriter)
        {
            this.JsonSerializer.Serialize(textWriter, this);
        }

        public string ToJsonString()
        {
            using (var sw = new StringWriter())
            {
                Write(sw);
                return sw.ToString();
            }
        }
    }
}

