using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MoEmbed.Models;
using MoEmbed.Providers;

namespace MoEmbed
{
    public class MetadataService
    {
        private readonly ILogger<MetadataService> _logger;
        private const string JSON_CONTENT_TYPE = "application/json";

        private List<IMetadataProvider> _Providers;

        public List<IMetadataProvider> Providers
            => _Providers ?? (_Providers = new List<IMetadataProvider>());

        public MetadataService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MetadataService>();
        }

        public async Task Embed(HttpContext context)
        {
            var queries = context.Request.Query;
            var url = queries["url"].FirstOrDefault();
            var mw = int.TryParse(queries["max_width"].FirstOrDefault(), out int w) ? (int?)w : null;
            var mh = int.TryParse(queries["max_height"].FirstOrDefault(), out int h) ? (int?)h : null;
            var fmt = queries["format"].FirstOrDefault();

            if (string.IsNullOrEmpty(url))
            {
                context.Response.ContentType = JSON_CONTENT_TYPE;
                await context.Response.WriteAsync("{ \"error\": \"No URL given\" }");
            }
            else
            {
                string contentType;
                IResponseWriter writer;
                if (string.IsNullOrEmpty(fmt) || fmt == "json")
                {
                    contentType = JSON_CONTENT_TYPE;
                    writer = new JsonResponseWriter(context.Response.Body);
                }
                else if (fmt == "xml")
                {
                    contentType = "text/xml";
                    writer = new XmlResponseWriter(context.Response.Body);
                }
                else
                {
                    context.Response.ContentType = JSON_CONTENT_TYPE;
                    await context.Response.WriteAsync("{ \"error\": \"Invalid format\" }");
                    return;
                }

                try
                {
                    _logger.LogInformation("Handling URL: {url}", url);
                    var req = new ConsumerRequest(new Uri(url), mw, mh, fmt);
                    foreach (var prov in Providers)
                    {
                        var m = prov.GetMetadata(req);
                        if (m != null)
                        {
                            _logger.LogInformation("Selected Provider: {0}", prov);
                            await m.FetchAsync();
                            context.Response.ContentType = contentType;
                            await m.WriteAsync(writer);
                            break;
                        }
                    }
                }
                catch (System.UriFormatException)
                {
                    context.Response.ContentType = JSON_CONTENT_TYPE;
                    var json = "{ \"error\": \"Invalid URL format. Please ensure you passed an URLEncoded URL.\" }";
                    await context.Response.WriteAsync(json);
                }
            }
        }
    }
}
