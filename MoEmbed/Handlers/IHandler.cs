using System;
using System.Threading.Tasks;
using MoEmbed.Models;

namespace MoEmbed
{
    namespace Handlers
    {
        interface IHandler
        {
            Uri Uri { get; set; }
            void Init(Uri uri);
            bool CanHandle();
            EmbedObject GetEmbedObject();
        }
    }
}

















