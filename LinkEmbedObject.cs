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

namespace MoEmbed
{
    class LinkEmbedObject : EmbedObject
    {
        public override string Type { get; set; } = "link";
        public override string Title { get; set; }
        public override string AuthorName { get; set; }

        // Requred properties of this type

        // Optional properties of this type

        public LinkEmbedObject(string uri) : this(new Uri(uri)) {}
        public LinkEmbedObject(Uri uri) {
            this.Title = $"Title of '{uri}'";
            this.AuthorName = $"AuthorName of '{uri}'";
        }
    }
}

















