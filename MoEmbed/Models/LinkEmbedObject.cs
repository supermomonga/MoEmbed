using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using Newtonsoft.Json;

namespace MoEmbed.Models
{
    class LinkEmbedObject : EmbedObject
    {
        // Requred properties of this type

        public override Types Type => Types.Link;

        // Optional properties of this type

        public LinkEmbedObject(string uri) : this(new Uri(uri)) { }
        public LinkEmbedObject(Uri uri) { }
        public async override Task FetchAsync()
        {
            // ~~~~
            this.Title = "fetched title";
        }
    }
}

