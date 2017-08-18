using System;
using System.Text;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public class UnknownMetadataProvider : IMetadataProvider
    {
        public bool CanHandle(ConsumerRequest request)
            => request.Url.Scheme == "http" || request.Url.Scheme == "https";

        public Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }
            return new UnknownMetadata()
            {
                Uri = request.Url.ToString(),
            };
        }
    }
}

