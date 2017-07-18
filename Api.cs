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
            var url = queries["url"];
            if (string.IsNullOrEmpty(url))
            {
                res = context.Response.WriteAsync($"No url given");
            } else {
                res = context.Response.WriteAsync($"Hello {url}");
            }
            return res;
        }
    }
}
















