using System;
using System.Text;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    public abstract partial class OEmbedProxyMetadataProvider : IMetadataProvider
    {
        public abstract bool CanHandle(Uri uri);

        public bool CanHandle(ConsumerRequest request)
            => CanHandle(request.Url);

        protected abstract Uri GetProviderUriFor(ConsumerRequest request);

        protected static Uri GetProviderUriWithoutFormat(string serviceUri, ConsumerRequest request)
        {
            var s = new StringBuilder(serviceUri);

            s.Append("?url=");
            s.Append(Uri.EscapeDataString(request.Url.ToString()));

            if (request.MaxWidth > 0)
            {
                s.Append("?max_width=");
                s.Append(request.MaxWidth.Value);
            }

            if (request.MaxHeight > 0)
            {
                s.Append("?max_height=");
                s.Append(request.MaxHeight.Value);
            }

            return new Uri(s.ToString());
        }
        protected static Uri GetProviderUriWithExtension(string serviceUri, ConsumerRequest request)
        {
            var s = new StringBuilder(serviceUri);
            s.Append('.');
            s.Append(string.IsNullOrEmpty(request.Format) ? "json" : request.Format);

            s.Append("?url=");
            s.Append(Uri.EscapeDataString(request.Url.ToString()));

            if (request.MaxWidth > 0)
            {
                s.Append("?max_width=");
                s.Append(request.MaxWidth.Value);
            }

            if (request.MaxHeight > 0)
            {
                s.Append("?max_height=");
                s.Append(request.MaxHeight.Value);
            }

            return new Uri(s.ToString());
        }
        protected static Uri GetProviderUriCore(string serviceUri, ConsumerRequest request)
        {
            var s = new StringBuilder(serviceUri);

            s.Append("?url=");
            s.Append(Uri.EscapeDataString(request.Url.ToString()));

            if (request.MaxWidth > 0)
            {
                s.Append("?max_width=");
                s.Append(request.MaxWidth.Value);
            }

            if (request.MaxHeight > 0)
            {
                s.Append("?max_height=");
                s.Append(request.MaxHeight.Value);
            }

            if (!string.IsNullOrEmpty(request.Format))
            {
                s.Append("?format=");
                s.Append(request.Format);
            }

            return new Uri(s.ToString());
        }

        public Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }
            return new OEmbedProxyMetadata()
            {
                Uri = request.Url.ToString(),
                OEmbedUrl = GetProviderUriFor(request).ToString()
            };
        }
    }
}
