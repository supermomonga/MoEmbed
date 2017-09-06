using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MoEmbed.Models.Imgur;
using MoEmbed.Providers;
using Newtonsoft.Json;
using Portable.Xaml.Markup;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the <see href="imgur.com"/>.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
    public class ImgurMetadata : UnknownMetadata
    {
        internal ImgurMetadataProvider Provider { get; set; }

        /// <summary>
        /// Gets or sets a type of imgur.com URL.
        /// </summary>
        [DefaultValue(default(ImgurType))]
        public ImgurType Type { get; set; }

        /// <summary>
        /// Gets or sets a URL hash in the URL.
        /// </summary>
        [DefaultValue(null)]
        public string Hash { get; set; }

        /// <inheritdoc />
        protected override async Task<EmbedData> FetchAsyncCore(RequestContext context)
        {
            var clientId = Provider?.ClientId;

            if (!string.IsNullOrEmpty(clientId)
                && DateTime.Now > Provider.LastFaulted + DefaultErrorResponseCacheAge)
            {
                if (Type == ImgurType.Unknown || string.IsNullOrEmpty(Hash))
                {
                    if (!ImgurMetadataProvider.ParseUrl(this))
                    {
                        Type = ImgurType.Unknown;
                        Hash = null;
                    }
                }

                switch (Type)
                {
                    case ImgurType.Image:
                        Data = await FetchImageAsync(context, clientId).ConfigureAwait(false);
                        break;

                    case ImgurType.Album:
                    case ImgurType.Gallery:
                    default:
                        Data = null;
                        break;
                }

                if (Data != null)
                {
                    return Data;
                }
            }

            var data = await base.FetchAsyncCore(context);
            data.Type = EmbedDataTypes.SingleImage;
            data.Medias.Add(data.MetadataImage);
            return data;
        }

        private async Task<EmbedData> FetchImageAsync(RequestContext context, string clientId)
        {
            var hc = context.Service.HttpClient;

            for (var i = 0; ; i++)
            {
                try
                {
                    var req = new HttpRequestMessage(HttpMethod.Get, "https://api.imgur.com/3/image/" + Hash);
                    req.Headers.Authorization = new AuthenticationHeaderValue("Client-ID", clientId);
                    req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var res = await hc.SendAsync(req).ConfigureAwait(false);

                    res.EnsureSuccessStatusCode();

                    ImgurImage img;
                    using (var s = await res.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var sr = new StreamReader(s))
                    using (var jr = new JsonTextReader(sr))
                    {
                        img = new JsonSerializer().Deserialize<ImgurResponse<ImgurImage>>(jr)?.Data;
                    }

                    if (img == null)
                    {
                        return null;
                    }

                    var url = "https://imgur.com/" + img.Id;
                    var policy = img.Nsfw == null ? RestrictionPolicies.Unknown
                                            : img.Nsfw.Value ? RestrictionPolicies.Restricted
                                            : RestrictionPolicies.Safe;

                    var thumbScale = Math.Min(320f / Math.Max(img.Width, img.Height), 1);

                    var media = new Media()
                    {
                        RawUrl = img.Link,
                        Location = url,
                        Type = img.IsAnimated ? MediaTypes.Video : MediaTypes.Image,
                        RestrictionPolicy = policy,
                        Thumbnail = new ImageInfo()
                        {
                            Url = "https://imgur.com/" + img.Id + "m" + Path.GetExtension(img.Link),
                            Width = (int)(img.Width * thumbScale),
                            Height = (int)(img.Height * thumbScale)
                        }
                    };

                    var d = new EmbedData()
                    {
                        Url = url,
                        Title = img.Title,
                        Description = img.Description,
                        Type = img.IsAnimated ? EmbedDataTypes.SingleVideo : EmbedDataTypes.SingleImage,
                        ProviderName = "Imgur",
                        ProviderUrl = "https://imgur.com",
                        RestrictionPolicy = policy,
                        MetadataImage = media,
                        Medias = new[] { media }
                    };

                    return d;
                }
                catch
                {
                    // TODO: log exception
                    if (i < RequestRetryCount)
                    {
                        try
                        {
                            await Task.Delay((int)(RequestRetryWait.TotalMilliseconds * Math.Pow(RequestRetryFactor, i))).ConfigureAwait(false);

                            continue;
                        }
                        catch { }
                    }

                    Provider.LastFaulted = DateTime.Now;
                    throw;
                }
            }
        }

        /// <inheritdoc />
        public override void OnDeserialized(MetadataService service)
        {
            Provider = service.Providers.OfType<ImgurMetadataProvider>().FirstOrDefault();
        }
    }
}