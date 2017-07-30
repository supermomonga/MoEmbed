using System;
using System.Text;
using MoEmbed.Models;

namespace MoEmbed.Providers
{
    public abstract partial class RemoteMetadataProvider : IMetadataProvider
    {
        public abstract bool CanHandle(Uri uri);

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

        public Metadata GetEmbedObject(Uri uri)
            => new RemoteMetadata()
            {
                Uri = uri,
                OEmbedUrl = GetProviderUriFor(new ConsumerRequest(uri))
            };
    }
}
