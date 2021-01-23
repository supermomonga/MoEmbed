using System;
using System.Collections.Generic;
using System.Text;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;

namespace MoEmbed.Providers
{
    /// <summary>
    /// Provides a IMetadataProvider base class to access the known oEmbed provider.
    /// </summary>
    public abstract partial class OEmbedProxyMetadataProvider : IMetadataProvider
    {
        bool IMetadataProvider.SupportsAnyHost => false;

        bool IMetadataProvider.IsEnabled
            => true;

        /// <summary>
        /// Returns a sequence of host names that is able to handle.
        /// </summary>
        /// <returns>The sequence of host names.</returns>
        public abstract IEnumerable<string> GetSupportedHostNames();

        /// <summary>
        /// Determines whether this provider can handle the specified URL.
        /// </summary>
        /// <param name="url">The URL to handle.</param>
        /// <returns>
        /// <c>true</c> if this provider can handle <paramref name="url" />; otherwise <c>false</c>.
        /// </returns>
        public abstract bool CanHandle(Uri url);

        /// <summary>
        /// Determines whether this provider can handle the specified request.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// <c>true</c> if this provider can handle <paramref name="request" />; otherwise <c>false</c>.
        /// </returns>
        public bool CanHandle(ConsumerRequest request)
            => CanHandle(request.Url);

        /// <summary>
        /// Returns a URL to request oEmbed provider.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>The provider URL.</returns>
        protected abstract Uri GetProviderUriFor(ConsumerRequest request);

        /// <summary>
        /// Returns a URL appended by oEmbed parameters without format.
        /// </summary>
        /// <param name="serviceUri">The end point of the oEmbed service.</param>
        /// <param name="request">The oEmbed request.</param>
        /// <returns>The provider URL.</returns>
        protected static Uri GetProviderUriWithoutFormat(string serviceUri, ConsumerRequest request)
        {
            var s = new StringBuilder(serviceUri);

            s.Append("?url=");
            s.Append(Uri.EscapeDataString(request.Url.ToString()));

            if (request.MaxWidth > 0)
            {
                s.Append("&max_width=");
                s.Append(request.MaxWidth.Value);
            }

            if (request.MaxHeight > 0)
            {
                s.Append("&max_height=");
                s.Append(request.MaxHeight.Value);
            }

            return new Uri(s.ToString());
        }

        /// <summary>
        /// Returns a URL appended by file extension and oEmbed parameters.
        /// </summary>
        /// <param name="serviceUri">The end point of the oEmbed service.</param>
        /// <param name="request">The oEmbed request.</param>
        /// <returns>The provider URL.</returns>
        protected static Uri GetProviderUriWithExtension(string serviceUri, ConsumerRequest request)
        {
            var s = new StringBuilder(serviceUri);
            s.Append('.');
            s.Append(string.IsNullOrEmpty(request.Format) ? "json" : request.Format);

            s.Append("?url=");
            s.Append(Uri.EscapeDataString(request.Url.ToString()));

            if (request.MaxWidth > 0)
            {
                s.Append("&max_width=");
                s.Append(request.MaxWidth.Value);
            }

            if (request.MaxHeight > 0)
            {
                s.Append("&max_height=");
                s.Append(request.MaxHeight.Value);
            }

            return new Uri(s.ToString());
        }

        /// <summary>
        /// Returns a URL appended by oEmbed parameters.
        /// </summary>
        /// <param name="serviceUri">The end point of the oEmbed service.</param>
        /// <param name="request">The oEmbed request.</param>
        /// <returns>The provider URL.</returns>
        protected static Uri GetProviderUriCore(string serviceUri, ConsumerRequest request)
        {
            var s = new StringBuilder(serviceUri);

            s.Append("?url=");
            s.Append(Uri.EscapeDataString(request.Url.ToString()));

            if (request.MaxWidth > 0)
            {
                s.Append("&max_width=");
                s.Append(request.MaxWidth.Value);
            }

            if (request.MaxHeight > 0)
            {
                s.Append("&max_height=");
                s.Append(request.MaxHeight.Value);
            }

            if (!string.IsNullOrEmpty(request.Format))
            {
                s.Append("&format=");
                s.Append(request.Format);
            }

            return new Uri(s.ToString());
        }

        /// <summary>
        /// Returns a <see cref="Metadata" /> that represents the specified URL.
        /// </summary>
        /// <param name="request">The consumer request to handle.</param>
        /// <returns>
        /// The <see cref="Metadata" /> if this provider can handle <paramref name="request" />;
        /// otherwise <c>null</c>.
        /// </returns>
        public Metadata GetMetadata(ConsumerRequest request)
        {
            if (!CanHandle(request))
            {
                return null;
            }

            var m = CreateMetadata();

            m.Url = request.Url.ToString();
            m.OEmbedUrl = GetProviderUriFor(request).ToString();

            return m;
        }

        /// <summary>
        /// Returns a new instaince of the <see cref="OEmbedProxyMetadata" />
        /// </summary>
        /// <returns>A new instaince of the <see cref="OEmbedProxyMetadata" />.</returns>
        protected virtual OEmbedProxyMetadata CreateMetadata()
            => new OEmbedProxyMetadata();
    }
}