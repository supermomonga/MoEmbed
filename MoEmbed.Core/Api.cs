using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MoEmbed.Models;
using MoEmbed.Handlers;

namespace MoEmbed
{
    public class Api
    {
        private readonly ILogger<Api> _logger;
        private const string JSON_CONTENT_TYPE = "application/json";

        private List<IEmbedObjectHandler> _Handlers;

        public List<IEmbedObjectHandler> Handlers
            => _Handlers ?? (_Handlers = new List<IEmbedObjectHandler>());

        public Api(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Api>();
        }

        public async Task Embed(HttpContext context)
        {
            var queries = context.Request.Query;
            var url = queries["url"].ToString();
            if (string.IsNullOrEmpty(url))
            {
                context.Response.ContentType = JSON_CONTENT_TYPE;
                await context.Response.WriteAsync("{ \"error\": \"No URL given\" }");
            }
            else
            {
                var fmt = queries["format"].ToString();
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
                    var uri = new Uri(url);
                    var handler = Handlers.Find(h => h.CanHandle(uri));
                    _logger.LogInformation("Handler: {handler}", handler);
                    var embed = handler.GetEmbedObject(uri);
                    await embed.FetchAsync();

                    context.Response.ContentType = contentType;
                    await embed.WriteAsync(writer);
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
