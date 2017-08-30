using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace MoEmbed.Models.Metadata
{
    using static OEmbed.OEmbed;

    /// <summary>
    /// Represents the <see cref="Metadata"/> fetching from remote oEmbed providers.
    /// </summary>
    [Serializable]
    public class OEmbedProxyMetadata : Metadata
    {
        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the oEmbed servide URL.
        /// </summary>
        [DefaultValue(null)]
        public string OEmbedUrl { get; set; }

        /// <summary>
        /// Gets or sets the resolved data.
        /// </summary>
        [DefaultValue(null)]
        public EmbedData Data { get; set; }

        [NonSerialized]
        private Task<EmbedData> _FetchTask;

        /// <inheritdoc />
        public override Task<EmbedData> FetchAsync(RequestContext context)
        {
            lock (this)
            {
                if (_FetchTask == null)
                {
                    if (Data != null)
                    {
                        _FetchTask = Task.FromResult<EmbedData>(Data);
                    }
                    else
                    {
                        _FetchTask = FetchAsyncCore(context);
                        _FetchTask.ConfigureAwait(false);
                    }
                }
                return _FetchTask;
            }
        }

        private async Task<EmbedData> FetchAsyncCore(RequestContext context)
        {
            var hc = context.Service.HttpClient;

            var redirection = await hc.FollowRedirectAsync(OEmbedUrl).ConfigureAwait(false);

            var r = redirection.Message;
            r.EnsureSuccessStatusCode();

            var txt = await r.Content.ReadAsStringAsync().ConfigureAwait(false);

            Dictionary<string, object> values;
            if (r.Content.Headers.ContentType.MediaType == "text/xml")
            {
                values = new Dictionary<string, object>();
                var d = new XmlDocument();
                d.LoadXml(txt);

                foreach (XmlNode xn in d.DocumentElement.ChildNodes)
                {
                    if (xn.NodeType == XmlNodeType.Element)
                    {
                        var e = (XmlElement)xn;
                        // TODO: parse number
                        values[e.LocalName] = e.InnerText;
                    }
                }
            }
            else
            {
                var jo = JObject.Parse(txt);
                values = jo.ToObject<Dictionary<string, object>>();
            }

            return Data = CreateEmbedData(values);
        }

        /// <summary>
        /// Returns a new instance of the <see cref="EmbedData" /> class that is equivalent to the specified oEmbed data.
        /// </summary>
        /// <param name="values">The oEmbed data to convert.</param>
        /// <returns>A new instance of the <see cref="EmbedData" /> class.</returns>
        protected internal virtual EmbedData CreateEmbedData(Dictionary<string, object> values)
        {
            var data = new EmbedData()
            {
                Url = new Uri(Uri)
            };
            if (values.TryGetValue(TITLE, out var title))
            {
                data.Title = title?.ToString();
            }
            if (values.TryGetValue(AUTHOR_NAME, out var authorName))
            {
                data.AuthorName = authorName?.ToString();
            }
            if (values.TryGetValue(AUTHOR_URL, out var authorUrl))
            {
                data.AuthorUrl = authorUrl?.ToString().ToUri();
            }
            if (values.TryGetValue(PROVIDER_NAME, out var providerName))
            {
                data.ProviderName = providerName?.ToString();
            }
            if (values.TryGetValue(PROVIDER_URL, out var providerUrl))
            {
                data.ProviderUrl = providerUrl?.ToString().ToUri();
            }
            if (values.TryGetValue(CACHE_AGE, out var cacheAge))
            {
                data.CacheAge = (cacheAge as IConvertible).ToInt32(null);
            }

            values.TryGetValue(TYPE, out var typeObj);
            var type = typeObj?.ToString();
            switch (type)
            {
                case PHOTO_TYPE:
                    if (values.TryGetValue(URL, out var url))
                    {
                        var u = url?.ToString().ToUri();

                        values.TryGetValue(WIDTH, out var w);
                        values.TryGetValue(HEIGHT, out var h);

                        data.Type = EmbedDataTypes.SingleImage;
                        data.MetadataImage = new Media()
                        {
                            Type = MediaTypes.Image,
                            Thumbnail = new ImageInfo
                            {
                                Url = u,
                                Width = (w as IConvertible)?.ToInt32(null),
                                Height = (h as IConvertible)?.ToInt32(null)
                            },
                            RawUrl = u,
                            Location = u
                        };
                        data.Medias.Add(data.MetadataImage);
                    }

                    break;

                case VIDEO_TYPE:
                case LINK_TYPE:
                case RICH_TYPE:
                default:
                    if (values.TryGetValue(THUMBNAIL_URL, out var thumbnailUrl))
                    {
                        data.MetadataImage = new Media
                        {
                            Thumbnail = new ImageInfo
                            {
                                Url = thumbnailUrl?.ToString().ToUri()
                            }
                        };

                        if (values.TryGetValue(THUMBNAIL_WIDTH, out var thumbnailWidth))
                        {
                            data.MetadataImage.Thumbnail.Width = (thumbnailWidth as IConvertible).ToInt32(null);
                        }
                        if (values.TryGetValue(THUMBNAIL_HEIGHT, out var thumbnailHeight))
                        {
                            data.MetadataImage.Thumbnail.Height = (thumbnailHeight as IConvertible).ToInt32(null);
                        }
                    }
                    if (type == VIDEO_TYPE)
                    {
                        // TODO: parse video url from html parameter
                        data.Type = EmbedDataTypes.SingleVideo;

                        if (data.MetadataImage != null)
                        {
                            data.MetadataImage.RawUrl = data.MetadataImage.Location = Uri.ToUri();

                            data.Medias.Add(data.MetadataImage);
                        }
                    }

                    break;
            }

            return data;
        }
    }
}