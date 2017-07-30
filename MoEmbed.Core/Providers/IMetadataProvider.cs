using System;
using MoEmbed.Models;

namespace MoEmbed.Providers
{
    public interface IMetadataProvider
    {
        bool CanHandle(Uri uri);

        EmbedObject GetEmbedObject(Uri uri);
    }
}
