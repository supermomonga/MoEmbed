using System;
using System.Threading.Tasks;

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

