using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MoEmbed
{
    public class Api
    {
        public static Task Index(HttpContext context)
        {
            return context.Response.WriteAsync("Hello MoEmbed");
        }
    }
}

