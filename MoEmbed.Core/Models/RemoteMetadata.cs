using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace MoEmbed.Models
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> fetching from remote oEmbed providers.
    /// </summary>
    [Serializable]
    public class RemoteMetadata : Metadata
    {
        private Dictionary<string, object> _Values;

        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the oEmbed servide URL.
        /// </summary>
        [DefaultValue(null)]
        public Uri OEmbedUrl { get; set; }

        /// <inheritdoc />
        public override Types Type
        {
            get
            {
                if (_Values != null && _Values.TryGetValue("type", out object t) && Enum.TryParse<Types>(t?.ToString(), out Types e))
                {
                    return e;
                }
                return Types.Link;
            }
        }

        /// <inheritdoc />
        public override async Task FetchAsync()
        {
            if (_Values != null)
            {
                return;
            }

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
                            values[e.LocalName] = d.Value;
                        }
                    }
                }
                else
                {
                    var jo = JObject.Parse(txt);
                    values = jo.ToObject<Dictionary<string, object>>();
                }

                _Values = values;
            }
        }

        /// <inheritdoc />
        protected override void WriteProperties(IResponseWriter writer)
        {
            foreach (var kv in _Values)
            {
                writer.WritePropertyIfNeeded(kv.Key, kv.Value);
            }
        }
    }
}