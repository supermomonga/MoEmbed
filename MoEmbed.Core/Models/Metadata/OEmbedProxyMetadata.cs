using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace MoEmbed.Models.Metadata
{
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
        protected virtual EmbedData CreateEmbedData(Dictionary<string, object> values)
        {
            var data = new EmbedData()
            {
                Url = new Uri(Uri)
            };
            if (values.ContainsKey("title"))
            {
                data.Title = values["title"].ToString();
            }
            if (values.ContainsKey("author_name"))
            {
                data.AuthorName = values["author_name"].ToString();
            }
            if (values.ContainsKey("author_url"))
            {
                data.AuthorUrl = new Uri(values["author_url"].ToString());
            }
            if (values.ContainsKey("provider_name"))
            {
                data.ProviderName = values["provider_name"].ToString();
            }
            if (values.ContainsKey("provider_url"))
            {
                data.ProviderUrl = new Uri(values["provider_url"].ToString());
            }
            if (values.ContainsKey("cache_age"))
            {
                data.CacheAge = (values["cache_age"] as IConvertible).ToInt32(null);
            }
            if (values.ContainsKey("thumbnail_url"))
            {
                data.MetadataImage = new Media
                {
                    Thumbnail = new ImageInfo
                    {
                        Url = new Uri(values["thumbnail_url"].ToString())
                    }
                };
            }
            if (values.ContainsKey("thumbnail_width") && data.MetadataImage?.Thumbnail != null)
            {
                data.MetadataImage.Thumbnail.Width = (values["thumbnail_width"] as IConvertible).ToInt32(null);
            }
            if (values.ContainsKey("thumbnail_height") && data.MetadataImage?.Thumbnail != null)
            {
                data.MetadataImage.Thumbnail.Height = (values["thumbnail_height"] as IConvertible).ToInt32(null);
            }

            var embedType = values["type"] as string;
            if (embedType.StartsWith("photo"))
            {
                data.Type = EmbedDataTypes.SingleImage;
                data.MetadataImage = new Media()
                    {
                        Type = MediaTypes.Image,
                        Thumbnail = new ImageInfo
                        {
                            Url = new Uri(values["url"].ToString()),
                            Width = (values["width"] as IConvertible)?.ToInt32(null),
                            Height = (values["height"] as IConvertible)?.ToInt32(null)
                        },
                        RawUrl = new Uri(values["url"].ToString()),
                        Location = new Uri(values["url"].ToString())
                    };
                data.Medias.Add(data.MetadataImage);
            } else if (embedType.StartsWith("video"))
            {
                // TODO: parse video url from html parameter
                data.Type = EmbedDataTypes.SingleVideo;
                if (values.ContainsKey("thumbnail_url"))
                {
                    data.MetadataImage = new Media()
                        {
                            Type = MediaTypes.Video,
                            Thumbnail = new ImageInfo
                            {
                                Url = new Uri(values["thumbnail_url"].ToString()),
                            },
                            RawUrl = new Uri(Uri),
                            Location = new Uri(Uri)
                        };
                    data.Medias.Add(data.MetadataImage);
                }
            } else if (embedType.StartsWith("link"))
            {
            } else if (embedType.StartsWith("rich"))
            {
            }

            return data;
        }
    }
}
