﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using AmazonProductAdvtApi;
using MoEmbed.Providers;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata" /> for the URL of the Amazon.
    /// </summary>
    [Serializable]
    public sealed class AmazonMetadata : Metadata
    {
        internal AmazonMetadataProvider Provider { get; set; }

        /// <summary>
        /// Gets or sets the destination domain of marketplace.
        /// </summary>
        [DefaultValue(null)]
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the ASIN.
        /// </summary>
        [DefaultValue(null)]
        public string Asin { get; set; }

        /// <summary>
        /// Gets or sets the resolved data.
        /// </summary>
        [DefaultValue(null)]
        public EmbedData Data { get; set; }

        /// <inheritdoc />
        public override void OnDeserialized(MetadataService service)
        {
            Provider = service.Providers.OfType<AmazonMetadataProvider>().FirstOrDefault();
        }

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
            if (Provider == null || Destination == null || Asin == null)
            {
                return null;
            }
            var url = new SignedRequestHelper(Provider.AccessKeyId, Provider.SecretKey, "webservices." + Destination).Sign(new Dictionary<string, string>()
            {
                ["Service"] = "AWSECommerceService",
                ["Operation"] = "ItemLookup",
                ["AWSAccessKeyId"] = Provider.AccessKeyId,
                ["AssociateTag"] = Provider.AssociateTag,
                ["ItemId"] = Asin,
                ["IdType"] = "ASIN",
                ["ResponseGroup"] = "Images,ItemAttributes",
            });

            var res = (await context.Service.HttpClient.FollowRedirectAsync(url).ConfigureAwait(false)).Message;

            res.EnsureSuccessStatusCode();

            var s = await res.Content.ReadAsStringAsync();

            var xd = new XmlDocument();
            xd.LoadXml(s);

            foreach (XmlElement asin in xd.GetElementsByTagName("ASIN", "http://webservices.amazon.com/AWSECommerceService/2011-08-01"))
            {
                if (!Asin.Equals(asin.InnerText, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var item = (XmlElement)asin.ParentNode;
                var attributes = item.Element("ItemAttributes");
                var title = attributes?.Element("Title")?.InnerText;

                if (title == null)
                {
                    continue;
                }

                var sn = char.ToUpper(Destination[0]) + Destination.Substring(1);

                var d = new EmbedData()
                {
                    Title = $"{title} - {sn}",
                    Url = new Uri($"https://www.{Destination}/dp/{Asin}"),
                    ProviderName = sn,
                    ProviderUrl = new Uri($"https://www.{Destination}"),
                };

                var imageSets = item.Element("ImageSets");

                if (imageSets != null)
                {
                    var elems = imageSets.Elements("ImageSet").Select(el => new
                    {
                        Category = el.GetAttribute("Category"),
                        Image = el.ChildNodes
                                    .OfType<XmlElement>()
                                    .Select(ce => new ImageInfo
                                    {
                                        Url = ce.Element("URL")?.InnerText.ToUri(),
                                        Width = int.TryParse(ce.Element("Width")?.InnerText, out var w) ? w : -1,
                                        Height = int.TryParse(ce.Element("Height")?.InnerText, out var h) ? h : -1,
                                    })
                                    .Where(e => e.Url != null && e.Width * e.Height > 0)
                                    .OrderByDescending(e => e.Width * e.Height)
                                    .FirstOrDefault()
                    }).Where(e => e.Image != null).OrderBy(e => e.Category == "primary" ? 0 : 1).ToArray();

                    if (elems.Any())
                    {
                        d.Thumbnail = new Media()
                        {
                            Type = MediaTypes.Image,
                            RawUrl = elems[0].Image.Url,
                        };

                        if (elems.Length > 1)
                        {
                            d.Medias = elems.Skip(1).Select(e => new Media()
                            {
                                Type = MediaTypes.Image,
                                RawUrl = e.Image.Url
                            }).ToList();
                        }
                    }
                }

                return Data = d;
            }

            return null;
        }
    }
}