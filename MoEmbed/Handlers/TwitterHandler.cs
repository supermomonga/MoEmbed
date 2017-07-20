
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MoEmbed.Models;

namespace MoEmbed.Handlers
{
    class TwitterHandler : IHandler
    {
        public Uri Uri { get; set; }

        public TwitterHandler(string uriString)
        {
            var uri = new Uri(uriString);
            this.Init(uri);
        }

        public TwitterHandler(Uri uri)
        {
            this.Init(uri);
        }

        public void Init(Uri uri)
        {
            this.Uri = uri;
        }

        public bool CanHandle()
        {
            var regex = new Regex(@"https:\/\/twitter\.com\/[^\/]+\/status\/\d+");
            return regex.IsMatch(this.Uri.ToString());
        }

        public EmbedObject GetEmbedObject()
        {
            // TODO: implement this.
            return new LinkEmbedObject(this.Uri);
        }
    }
}
