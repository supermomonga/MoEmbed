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
        public static Task Embed(HttpContext context)
        {
            Task res;
            var queries = context.Request.Query;
            var url = queries["url"].ToString();
            if (string.IsNullOrEmpty(url))
            {
                res = context.Response.WriteAsync("{ error: 'No URL given' }");
            }
            else
            {
                string json;
                try
                {
                    var handlers = new List<IHandler> {
                        new TwitterHandler(url)
                    };
                    var handler = handlers.Find(h => h.CanHandle());
                    var embed = handler.GetEmbedObject();
                    json = embed.ToJsonString();
                }
                catch (System.UriFormatException)
                {
                    json = "{ error: 'Invalid URL format. Please ensure you passed an URLEncoded URL.' }";
                }
                res = context.Response.WriteAsync(json);
            }
            return res;
        }
    }
}













