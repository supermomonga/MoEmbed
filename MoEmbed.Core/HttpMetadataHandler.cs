using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MoEmbed.Models;

namespace MoEmbed
{
    public class HttpMetadataHandler
    {
        private readonly ILogger<HttpMetadataHandler> _Logger;
        private readonly MetadataService _Service;
        private const string JSON_CONTENT_TYPE = "application/json";

        public HttpMetadataHandler(ILoggerFactory loggerFactory, MetadataService service)
        {
            _Logger = loggerFactory.CreateLogger<HttpMetadataHandler>();
            _Service = service;
        }

        public async Task HandleAsync(HttpContext context)
        {
            var queries = context.Request.Query;
            var url = queries["url"].FirstOrDefault();
            var fmt = queries["format"].FirstOrDefault();

            EmbedDataResult result = null;
            string contentType = null;
            IResponseWriter writer = null;
            try
            {
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
                    result = new EmbedDataResult()
                    {
                        Succeeded = false,
                        ErrorMessage = "Invalid format."
                    };
                }
                if (result == null)
                {
                    if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri))
                    {
                        _Logger.LogInformation("Handling URL: {0}", url);

                        var mw = int.TryParse(queries["max_width"].FirstOrDefault(), out int w) ? (int?)w : null;
                        var mh = int.TryParse(queries["max_height"].FirstOrDefault(), out int h) ? (int?)h : null;
                        var req = new ConsumerRequest(new Uri(url), mw, mh, fmt);
                        result = await _Service.GetDataAsync(req).ConfigureAwait(false);
                    }
                    else
                    {
                        result = new EmbedDataResult()
                        {
                            Succeeded = false,
                            ErrorMessage = "Invalid URL."
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _Logger.LogInformation("An exception thrown: {0}", ex);

                result = new EmbedDataResult()
                {
                    Succeeded = false,
                    ErrorMessage = "Internal server error."
                };

                if (writer == null)
                {
                    contentType = JSON_CONTENT_TYPE;
                    writer = new JsonResponseWriter(context.Response.Body);
                }
            }

            if (!result.Succeeded)
            {
                context.Response.StatusCode = 404;
            }
            context.Response.ContentType = contentType;
            if (result.Data != null)
            {
                writer.WriteEmbedData(result.Data);
            }
            else
            {
                writer.WriteStartResponse();
                writer.WriteProperty("error", result.ErrorMessage);
                writer.WriteEndResponse();
            }
        }
    }
}