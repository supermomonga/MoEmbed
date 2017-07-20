using System;
using System.Threading.Tasks;
using MoEmbed.Models;

namespace MoEmbed.Handlers
{
    interface IHandler
    {
        bool CanHandle(Uri uri);
        EmbedObject GetEmbedObject(Uri uri);
    }
}

