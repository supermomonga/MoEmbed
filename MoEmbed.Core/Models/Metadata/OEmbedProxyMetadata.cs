using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using MoEmbed.Models.OEmbed;
using System.Linq;
using System.Reflection;

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

        [DefaultValue(null)]
        public EmbedData Data { get; set; }

        [NonSerialized]
        private Task<EmbedData> _FetchTask;

        /// <inheritdoc />
        public override Task<EmbedData> FetchAsync()
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
                        _FetchTask = FetchAsyncCore();
                        _FetchTask.ConfigureAwait(false);
                    }
                }
                return _FetchTask;
            }
        }

        private async Task<EmbedData> FetchAsyncCore()
        {
            using (var hc = new HttpClient())
            {
                // TODO: share HttpClient in service

                var r = await hc.GetAsync(OEmbedUrl).ConfigureAwait(false);

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

                Data = new EmbedData(){
                    Url = new Uri(Uri)
                };
                if(values.ContainsKey("title"))
                {
                    Data.Title = values["title"].ToString();
                }
                if(values.ContainsKey("author_name"))
                {
                    Data.AuthorName = values["author_name"].ToString();
                }
                if(values.ContainsKey("author_url"))
                {
                    Data.AuthorUrl = new Uri(values["author_url"].ToString());
                }
                if(values.ContainsKey("provider_name"))
                {
                    Data.ProviderName = values["provider_name"].ToString();
                }
                if(values.ContainsKey("provider_url"))
                {
                    Data.ProviderUrl = new Uri(values["provider_url"].ToString());
                }
                if(values.ContainsKey("cache_age"))
                {
                    Data.CacheAge = (values["cache_age"] as IConvertible).ToInt32(null);
                }
                if(values.ContainsKey("thumbnail_url"))
                {
                    Data.ThumbnailUrl = new Uri(values["thumbnail_url"].ToString());
                }
                if(values.ContainsKey("thumbnail_width"))
                {
                    Data.ThumbnailWidth = (values["thumbnail_width"] as IConvertible).ToInt32(null);
                }
                if(values.ContainsKey("thumbnail_height"))
                {
                    Data.ThumbnailHeight = (values["thumbnail_height"] as IConvertible).ToInt32(null);
                }
                return Data;
            }
        }
    }
}


