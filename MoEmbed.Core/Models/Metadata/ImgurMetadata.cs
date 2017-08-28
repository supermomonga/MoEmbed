using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the unknown URL.
    /// </summary>
    [Serializable]
    public class ImgurMetadata : UnknownMetadata
    {
        public ImgurMetadata()
        {
        }

        public ImgurMetadata(string uri)
        {
            Uri = uri;
        }

        public ImgurMetadata(Uri uri)
        {
            Uri = uri.ToString();
        }

        protected override async Task<EmbedData> FetchAsyncCore(RequestContext context)
        {
            var Data = await base.FetchAsyncCore(context);
            Data.Type = EmbedDataTypes.SingleImage;
            return Data;
        }

    }
}
