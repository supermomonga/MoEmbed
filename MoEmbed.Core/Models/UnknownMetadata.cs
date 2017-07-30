using System;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the unknown URL.
    /// </summary>
    [Serializable]
    public class UnknownMetadata : Metadata, ILinkEmbedObject
    {
        public UnknownMetadata()
        {
        }

        public UnknownMetadata(string uri)
            : this(new Uri(uri))
        {
        }

        public UnknownMetadata(Uri uri)
        {
            Uri = uri;
        }

        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the URL the <see cref="Uri" /> moved to.
        /// </summary>
        [DefaultValue(null)]
        public Uri MovedTo { get; set; }

        #region IEmbedObject Properties

        /// <inheritdoc />
        public override Types Type => Types.Link;

        string IEmbedObject.Type
            => TypeString;

        /// <summary>
        /// Gets or sets a text title, describing the resource.
        /// </summary>
        [DefaultValue(null)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name of the author/owner of the resource.
        /// </summary>
        [DefaultValue(null)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Gets or sets a URL for the author/owner of the resource.
        /// </summary>
        [DefaultValue(null)]
        public Uri AuthorUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource provider.
        /// </summary>
        [DefaultValue(null)]
        public string ProviderName { get; set; }

        /// <summary>
        /// Gets or sets the url of the resource provider.
        /// </summary>
        [DefaultValue(null)]
        public Uri ProviderUrl { get; set; }

        /// <summary>
        /// Gets or sets the suggested cache lifetime for this resource, in seconds. Consumers may choose to use this value or not.
        /// </summary>
        [DefaultValue(null)]
        public int? CacheAge { get; set; }

        /// <summary>
        /// Gets or sets a URL to a thumbnail image representing the resource.
        /// </summary>
        /// <remarks>
        /// The thumbnail must respect any <see cref="ConsumerRequest.MaxWidth"/> and <see cref="ConsumerRequest.MaxHeight"/> parameters.
        /// If this parameter is present, <see cref="ThumbnailWidth" /> and <see cref="ThumbnailHeight" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public Uri ThumbnailUrl { get; set; }

        /// <summary>
        /// Gets or sets the width of the optional thumbnail.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="ThumbnailUrl" /> and <see cref="ThumbnailHeight" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public int? ThumbnailWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the optional thumbnail.
        /// </summary>
        /// <remarks>
        /// If this parameter is present, <see cref="ThumbnailUrl" /> and <see cref="ThumbnailWidth" /> must also be present.
        /// </remarks>
        [DefaultValue(null)]
        public int? ThumbnailHeight { get; set; }

        #endregion IEmbedObject Properties

        protected override void WriteProperties(IResponseWriter writer)
        {
            writer.WriteDefaultProperties((ILinkEmbedObject)this);
        }

        /// <inheritdoc />
        public async override Task FetchAsync()
        {
            using (var hh = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            })
            using (var hc = new HttpClient(hh))
            {
                // TODO: share HttpClient in service

                var res = await GetResponseAsync(hc).ConfigureAwait(false);
                if (!res.IsSuccessStatusCode)
                {
                    return;
                }

                var mediaType = res.Content.Headers.ContentType.MediaType;

                if (Regex.IsMatch(mediaType, @"^text\/html$"))
                {
                    LoadHtml(await res.Content.ReadAsStringAsync());
                }
                else if (Regex.IsMatch(mediaType, @"^image\/"))
                {
                }
                else if (Regex.IsMatch(mediaType, @"^video\/"))
                {
                }
                else
                {
                }
            }
        }

        private async Task<HttpResponseMessage> GetResponseAsync(HttpClient hc)
        {
            var u = MovedTo ?? Uri;
            for (;;)
            {
                var res = await hc.GetAsync(u).ConfigureAwait(false);

                switch (res.StatusCode)
                {
                    case HttpStatusCode.Moved:
                        if (u == (MovedTo ?? Uri))
                        {
                            MovedTo = res.Headers.Location;
                        }
                        u = res.Headers.Location;
                        continue;
                    case HttpStatusCode.Ambiguous:
                    case HttpStatusCode.Found:
                    case HttpStatusCode.RedirectMethod:
                        u = res.Headers.Location;
                        continue;
                }

                return res;
            }
        }

        private void LoadHtml(string html)
        {
            var hd = new HtmlDocument();
            hd.LoadHtml(html);

            var nav = hd.CreateNavigator();
            Title = nav.SelectSingleNode("//html/head/title/text()")?.Value;
        }
    }
}