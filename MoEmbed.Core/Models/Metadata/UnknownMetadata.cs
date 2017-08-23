using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
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
                    return null;
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
                        Url = u,
                        ThumbnailUrl = mediaType[0] == 'i' ? u : null,
                        Medias = new List<Media>(1)
                        {
                            new Media()
                            {
                                Type =mediaType[0] == 'i' ?  MediaTypes.Image
                                        :mediaType[0] == 'v' ?  MediaTypes.Video
                                        : MediaTypes.Audio,
                                RawUri = u
                            }
                        }
                    };
                }

                if (Data != null)
                {
                    Data.Title = Data.Title ?? Path.GetFileNameWithoutExtension(MovedTo ?? Uri);
                    Data.CacheAge = Data.CacheAge ?? (int?)res.Headers.CacheControl?.MaxAge?.TotalSeconds;
                }
            }
            return Data;
        }

        private async Task<HttpResponseMessage> GetResponseAsync(HttpClient hc)
        {
            var u = MovedTo ?? Uri;
            for (; ; )
            {
                var res = await hc.GetAsync(u).ConfigureAwait(false);

                switch (res.StatusCode)
                {
                    case HttpStatusCode.Moved:
                        if (u == (MovedTo ?? Uri))
                        {
                            MovedTo = res.Headers.Location.ToString();
                        }
                        u = res.Headers.Location.ToString();
                        continue;
                    case HttpStatusCode.Ambiguous:
                    case HttpStatusCode.Found:
                    case HttpStatusCode.RedirectMethod:
                        u = res.Headers.Location.ToString();
                        continue;
                }

                return res;
            }
        }

        private void LoadHtml(string html)
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
                Data.AuthorName = author.Title.DeEntitize();
                Data.AuthorUrl = author.Url.DeEntitize().ToUri();
            }

            foreach (var img in graph.Images)
            {
                var url = (img.SecureUrl ?? img.Url).DeEntitize().ToUri();

                if (url != null)
                {
                    if (Data.ThumbnailUrl == null)
                    {
                        Data.ThumbnailUrl = url;
                        Data.ThumbnailWidth = img.Width;
                        Data.ThumbnailHeight = img.Height;
                    }
                    Data.Medias.Add(new Media()
                    {
                        Type = MediaTypes.Image,
                        ThumbnailUri = url,
                        RawUri = url,
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
                        ThumbnailUri = (v.Image?.SecureUrl ?? v.Image?.Url).DeEntitize().ToUri(),
                        RawUri = url,
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
                        ThumbnailUri = (a.Image?.SecureUrl ?? a.Image?.Url).DeEntitize().ToUri(),
                        RawUri = url,
                        Location = Data.Url,
                    });
                }
            }

            var age = graph.Restriction?.Age;
            Data.Nsfw = age != null && int.TryParse(age.TrimEnd('+'), out var a) && a >= 18;
        }
    }
}