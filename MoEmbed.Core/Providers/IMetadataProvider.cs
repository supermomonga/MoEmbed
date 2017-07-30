using System;
using MoEmbed.Models;

namespace MoEmbed.Providers
{
    public interface IMetadataProvider
    {
        bool CanHandle(ConsumerRequest  request);

        Metadata GetMetadata(ConsumerRequest request);
    }
}
