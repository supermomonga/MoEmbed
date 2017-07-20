using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MoEmbed.Models;
using MoEmbed.Handlers;

namespace MoEmbed
{
    public class Api
    {
        private static readonly List<IHandler> handlers = new List<IHandler> {
            new TwitterHandler()
        };

        public static async Task Embed(HttpContext context)
        {
            Task res;
            var queries = context.Request.Query;
            var url = queries["url"].ToString();
            if (string.IsNullOrEmpty(url))
            {
                await context.Response.WriteAsync("{ \"error\": \"No URL given\" }");
            }
            else
            {
                string json;
                try
                {
                    var uri = new Uri(url);
                    var handler = handlers.Find(h => h.CanHandle(uri));
                    var embed = handler.GetEmbedObject(uri);
                    await embed.FetchAsync();
                    json = embed.ToJsonString();
                }
                catch (System.UriFormatException)
                {
                    json = "{ \"error\": \"Invalid URL format. Please ensure you passed an URLEncoded URL.\" }";
                }
                await context.Response.WriteAsync(json);
            }
        }
    }
}













