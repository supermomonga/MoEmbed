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
                        Data = await FetchAlbumAsync(context, clientId).ConfigureAwait(false);
                        break;

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

                    return GetEmbedData(img);
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

        private async Task<EmbedData> FetchAlbumAsync(RequestContext context, string clientId)
        {
            var hc = context.Service.HttpClient;

            for (var i = 0; ; i++)
            {
                try
                {
                    var req = new HttpRequestMessage(HttpMethod.Get, "https://api.imgur.com/3/album/" + Hash);
                    req.Headers.Authorization = new AuthenticationHeaderValue("Client-ID", clientId);
                    req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var res = await hc.SendAsync(req).ConfigureAwait(false);

                    res.EnsureSuccessStatusCode();

                    ImgurAlbum album;
                    using (var s = await res.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var sr = new StreamReader(s))
                    using (var jr = new JsonTextReader(sr))
                    {
                        album = new JsonSerializer().Deserialize<ImgurResponse<ImgurAlbum>>(jr)?.Data;
                    }

                    if (!(album?.Images?.Length > 0))
                    {
                        return null;
                    }

                    var ci = album.Images.FirstOrDefault(im => im.Id == album.Cover) ?? album.Images[0];
                    var d = GetEmbedData(ci);
                    d.Url = "https://imgur.com/a/" + album.Id;
                    d.Title = album.Title ?? d.Title;
                    d.Description = album.Description ?? d.Description;

                    if (album.Images.Length > 1)
                    {
                        d.Type = EmbedDataTypes.MixedContent;

                        foreach (var img in album.Images)
                        {
                            if (img != ci)
                            {
                                d.Medias.Add(img.ToMedia());
                            }
                        }
                    }

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

        private static EmbedData GetEmbedData(ImgurImage img)
        {
            var media = img.ToMedia();

            return new EmbedData()
            {
                Url = media.Location,
                Title = img.Title,
                Description = img.Description,
                Type = img.IsAnimated ? EmbedDataTypes.SingleVideo : EmbedDataTypes.SingleImage,
                ProviderName = "Imgur",
                ProviderUrl = "https://imgur.com",
                RestrictionPolicy = media.RestrictionPolicy,
                MetadataImage = media,
                Medias = new[] { media }
            };
        }

        /// <inheritdoc />
        public override void OnDeserialized(MetadataService service)
        {
            Provider = service.Providers.OfType<ImgurMetadataProvider>().FirstOrDefault();
        }
    }
}