using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

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
                res = context.Response.WriteAsync($"No url given");
            } else {
                var embed = new LinkEmbedObject(url);
                var json = embed.ToJsonString();
                res = context.Response.WriteAsync(json);
            }
            return res;
        }
    }
}
















