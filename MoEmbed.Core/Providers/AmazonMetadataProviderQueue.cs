using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using AmazonProductAdvtApi;
using MoEmbed.Models;

namespace MoEmbed.Providers
{
    internal sealed class AmazonMetadataProviderQueue
    {
        internal sealed class Item
        {
            public Item(string destination, string asin)
            {
                Destination = destination;
                Asin = asin;
                Retry = 3;
                CompletionSource = new TaskCompletionSource<EmbedData>();
            }

            public string Destination { get; }

            public string Asin { get; }

            public int Retry { get; set; }

            public TaskCompletionSource<EmbedData> CompletionSource { get; }
        }

        private readonly string AccessKeyId;
        private readonly string SecretKey;
        private readonly string AssociateTag;

        private readonly List<Item> _Items;

        private DateTime _LastRequest;

        public AmazonMetadataProviderQueue(string accessKeyId, string secretKey, string associateTag)
        {
            AccessKeyId = accessKeyId;
            SecretKey = secretKey;
            AssociateTag = associateTag;

            _Items = new List<Item>();
        }

        public Task<EmbedData> Enqueue(HttpClient client, string destination, string asin)
        {
            var item = new Item(destination, asin);
            lock (_Items)
            {
                _Items.Add(item);

                if (_Items.Count == 1)
                {
                    Run(client);
                }
            }

            return item.CompletionSource.Task;
        }

        private async void Run(HttpClient client)
        {
            for (; ; )
            {
                Item item;
                lock (_Items)
                {
                    for (; ; )
                    {
                        if (_Items.Count == 0)
                        {
                            return;
                        }
                        item = _Items[0];
                        if (item.Retry <= 0 || item.CompletionSource.Task.IsCompleted)
                        {
                            _Items.RemoveAt(0);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                try
                {
                    var wait = _LastRequest.AddSeconds(1.25) - DateTime.Now;
                    if (wait > TimeSpan.Zero)
                    {
                        await Task.Delay(wait);
                    }

                    var url = new SignedRequestHelper(AccessKeyId, SecretKey, "webservices." + item.Destination).Sign(new Dictionary<string, string>()
                    {
                        ["Service"] = "AWSECommerceService",
                        ["Operation"] = "ItemLookup",
                        ["AWSAccessKeyId"] = AccessKeyId,
                        ["AssociateTag"] = AssociateTag,
                        ["ItemId"] = item.Asin,
                        ["IdType"] = "ASIN",
                        ["ResponseGroup"] = "Images,ItemAttributes",
                    });

                    var res = (await client.FollowRedirectAsync(url).ConfigureAwait(false)).Message;
                    _LastRequest = DateTime.Now;

                    if (res.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        continue;
                    }

                    res.EnsureSuccessStatusCode();

                    var s = await res.Content.ReadAsStringAsync().ConfigureAwait(false);

                    item.CompletionSource.TrySetResult(ParseResponse(s, item));
                }
                catch (Exception ex)
                {
                    lock (_Items)
                    {
                        if (--item.Retry > 0)
                        {
                            continue;
                        }
                        else
                        {
                            _Items.Remove(item);
                        }
                    }
                    item.CompletionSource.TrySetException(ex);
                }
            }
        }

        private EmbedData ParseResponse(string xml, Item item)
        {
            var xd = new XmlDocument();
            xd.LoadXml(xml);

            foreach (XmlElement asin in xd.GetElementsByTagName("ASIN", "http://webservices.amazon.com/AWSECommerceService/2011-08-01"))
            {
                if (!item.Asin.Equals(asin.InnerText, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                var itemElem = (XmlElement)asin.ParentNode;
                var attributes = itemElem.Element("ItemAttributes");
                var title = attributes?.Element("Title")?.InnerText;

                if (title == null)
                {
                    continue;
                }

                var sn = char.ToUpper(item.Destination[0]) + item.Destination.Substring(1);

                var d = new EmbedData()
                {
                    Title = $"{title} - {sn}",
                    Url = new Uri($"https://www.{item.Destination}/dp/{item.Asin}"),
                    ProviderName = sn,
                    ProviderUrl = new Uri($"https://www.{item.Destination}"),
                };
                if(int.TryParse(attributes?.Element("IsAdultProduct")?.InnerText, out int i) && i > 0)
                {
                    d.RestrictedPolicy = RestrictionPolicies.Restricted;
                }

                var imageSets = itemElem.Element("ImageSets");

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
                            Thumbnail = elems[0].Image
                        };

                        if (elems.Length > 1)
                        {
                            d.Medias = elems.Skip(1).Select(e => new Media()
                            {
                                Type = MediaTypes.Image,
                                RawUrl = e.Image.Url,
                                RestrictionPolicy = d.RestrictedPolicy
                            }).ToList();
                        }
                    }
                }

                return d;
            }
            return null;
        }
    }
}
