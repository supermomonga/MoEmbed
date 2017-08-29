using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the unknown URL.
    /// </summary>
    [Serializable]
    public class UnknownMetadata : Metadata
    {
        public UnknownMetadata()
        {
        }

        public UnknownMetadata(string uri)
        {
            Uri = uri;
        }

        public UnknownMetadata(Uri uri)
        {
            Uri = uri.ToString();
        }

        /// <summary>
        /// Gets or sets the requested URL.
        /// </summary>
        [DefaultValue(null)]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the URL the <see cref="Uri" /> moved to.
        /// </summary>
        [DefaultValue(null)]
        public string MovedTo { get; set; }

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

        protected virtual async Task<EmbedData> FetchAsyncCore(RequestContext context)
        {
            var hc = context.Service.HttpClient;

            var res = await GetResponseAsync(hc).ConfigureAwait(false);
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }

            if (MovedTo != null && MovedTo != Uri)
            {
                var mcr = new ConsumerRequest(new Uri(MovedTo), context.MaxWidth, context.MaxHeight, context.Format);
                return Data = (await context.Service.GetDataAsync(mcr).ConfigureAwait(false)).Data;
            }

            var mediaType = res.Content.Headers.ContentType.MediaType;

            if (Regex.IsMatch(mediaType, @"^text\/html$"))
            {
                LoadHtml(await res.Content.ReadAsStringAsync());
            }
            else if (Regex.IsMatch(mediaType, @"^(image|video|audio)\/"))
            {
                var u = new Uri(MovedTo ?? Uri);
                Data = new EmbedData()
                {
                    Type = mediaType[0] == 'i' ? EmbedDataTypes.SingleImage
                    : mediaType[0] == 'v' ? EmbedDataTypes.SingleVideo
                    : EmbedDataTypes.SingleAudio,
                    Url = u,
                    Medias = new List<Media>(1)
                        {
                            new Media()
                            {
                                Type = mediaType[0] == 'i' ?  MediaTypes.Image
                                :mediaType[0] == 'v' ?  MediaTypes.Video
                                : MediaTypes.Audio,
                                RawUrl = u
                            }
                        }
                };
                if (mediaType.StartsWith("image"))
                {
                    Data.Type = EmbedDataTypes.SingleImage;
                    Data.MetadataImage = new Media
                    {
                        Type = MediaTypes.Image,
                        Thumbnail = new ImageInfo
                        {
                            Url = u
                        }
                    };
                }
            }

            if (Data != null)
            {
                Data.Title = Data.Title ?? Path.GetFileNameWithoutExtension(MovedTo ?? Uri);
                Data.CacheAge = Data.CacheAge ?? (int?)res.Headers.CacheControl?.MaxAge?.TotalSeconds;
            }

            return Data;
        }

        private async Task<HttpResponseMessage> GetResponseAsync(HttpClient hc)
        {
            var res = await hc.FollowRedirectAsync(MovedTo ?? Uri).ConfigureAwait(false);
            MovedTo = res.MovedTo ?? MovedTo;
            return res.Message;
        }

        protected virtual void LoadHtml(string html)
        {
            var hd = new HtmlDocument();
            hd.LoadHtml(html);

            // OGP Spec: http://ogp.me/
            var graph = Shipwreck.OpenGraph.Graph.FromXPathNavigable(hd);

            var nav = hd.CreateNavigator();
            // Open Graph protocol を優先しつつフォールバックする
            Data = new EmbedData()
            {
                Url = new Uri(graph.Url.DeEntitize() ?? MovedTo ?? Uri),
                Title = (graph.Title ?? nav.SelectSingleNode("//html/head/title/text()")?.Value).DeEntitize(),
                Description = (graph.Description ?? nav.SelectSingleNode("//html/head/meta[@name='description']/@content")?.Value).DeEntitize(),
                ProviderName = graph.SiteName.DeEntitize(),
                CacheAge = graph.TimeToLive
            };

            var author = graph.Article?.Author
                        ?? graph.Book?.Author
                        ?? graph.MusicAlbum?.Musician
                        ?? graph.MusicSong?.Musician
                        ?? graph.MusicPlaylist?.Creator
                        ?? graph.MusicRadioStation?.Creator
                        ?? graph.VideoEpisode?.Director
                        ?? graph.VideoMovie?.Director
                        ?? graph.VideoOther?.Director
                        ?? graph.VideoTVShow?.Director;

            if (author != null)
            {
                var authorRef = author.Url.DeEntitize();

                // Determines whether reference is absolute URL.
                if (System.Uri.TryCreate(authorRef, UriKind.Absolute, out var authorUri))
                {
                    Data.AuthorUrl = authorUri;

                    // As author is OGP Reference type, `:title` structured property is invalid.
                    // But try to read value.
                    Data.AuthorName = author.Title.DeEntitize();

                    // HACK: To acquire futher information, we can load OGP from authorURL.
                }
                else
                {
                    // authorRef can be Site specific ID.
                    Data.AuthorName = authorRef;
                }
            }

            foreach (var img in graph.Images)
            {
                var url = (img.SecureUrl ?? img.Url).DeEntitize().ToUri();

                if (url != null)
                {
                    Data.Medias.Add(new Media()
                    {
                        Type = MediaTypes.Image,
                        Thumbnail = new ImageInfo
                        {
                            Url = url
                        },
                        RawUrl = url,
                        Location = Data.Url,
                    });
                }
            }
            foreach (var v in graph.Videos)
            {
                var url = (v.SecureUrl ?? v.Url).DeEntitize().ToUri();

                if (url != null)
                {
                    Data.Medias.Add(new Media()
                    {
                        Type = MediaTypes.Video,
                        Thumbnail = new ImageInfo
                        {
                            Url = (v.Image?.SecureUrl ?? v.Image?.Url).DeEntitize().ToUri()
                        },
                        RawUrl = url,
                        Location = Data.Url,
                    });
                }
            }

            foreach (var a in graph.Audios)
            {
                var url = (a.SecureUrl ?? a.Url).DeEntitize().ToUri();

                if (url != null)
                {
                    Data.Medias.Add(new Media()
                    {
                        Type = MediaTypes.Audio,
                        Thumbnail = new ImageInfo
                        {
                            Url = (a.Image?.SecureUrl ?? a.Image?.Url).DeEntitize().ToUri()
                        },
                        RawUrl = url,
                        Location = Data.Url,
                    });
                }
            }

            {
                var medias = Data.Medias.Where(m => m.Thumbnail?.Url != null);
                if (medias.Count() == 1)
                {
                    var media = medias.First();
                    if (media.Thumbnail?.Url != null)
                    {
                        Data.MetadataImage = new Media
                        {
                            Thumbnail = new ImageInfo
                            {
                                Url = media.Thumbnail?.Url
                            }
                        };
                    }
                    Data.Medias.Remove(media);
                }
            }

            {
                var age = graph.Restriction?.Age;
                if (age != null && int.TryParse(age.TrimEnd('+'), out var a) && a >= 18)
                {
                    Data.RestrictionPolicy = RestrictionPolicies.Restricted;
                }
            }
        }
    }
}
