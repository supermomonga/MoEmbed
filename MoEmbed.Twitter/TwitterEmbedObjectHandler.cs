using System;
using System.Text.RegularExpressions;
using MoEmbed.Models;

namespace MoEmbed.Handlers
{
    public class TwitterEmbedObjectHandler : IEmbedObjectHandler
    {
        private static Regex regex = new Regex(@"https:\/\/twitter\.com\/[^\/]+\/status\/\d+");

        private string AccessToken { get; }

        public TwitterEmbedObjectHandler(string accessToken)
        {
            this.AccessToken = accessToken;
        }

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







