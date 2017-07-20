using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using Newtonsoft.Json;

namespace MoEmbed.Models
{
    abstract class EmbedObject
    {
        // See spec: http://oembed.com/#section2

        public abstract string Type { get; set; }

        // Version is fixed.
        public static string Version { get; } = "1.0";

        public abstract string Title { get; set; }

        // Below is optional properties
        public abstract string AuthorName { get; set; }

        protected JsonSerializer jsonSerializer { get; set; } = new JsonSerializer();

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
            this.jsonSerializer.Serialize(textWriter, this);
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

