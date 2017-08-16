using System;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public interface IMetadataProvider
    {
        bool CanHandle(ConsumerRequest  request);

        Metadata GetMetadata(ConsumerRequest request);
    }
}
