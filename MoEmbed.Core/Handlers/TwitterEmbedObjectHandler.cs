using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MoEmbed.Models;

namespace MoEmbed.Handlers
{
    public class TwitterEmbedObjectHandler : IEmbedObjectHandler
    {
        private static Regex regex = new Regex(@"https:\/\/twitter\.com\/[^\/]+\/status\/\d+");

        public bool CanHandle(Uri uri)
        {
            return regex.IsMatch(uri.ToString());
        }

        public EmbedObject GetEmbedObject(Uri uri)
        {
            // TODO: implement this.
            return new LinkEmbedObject(uri);
        }
    }
}
