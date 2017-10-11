using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;
using Portable.Xaml.Markup;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata"/> for the URL of the nicovideo.jp.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
    public class NicovideoMetadata : Metadata
    {
        /// <summary>
        /// Gets or sets the unique identifier of the video.
        /// </summary>
        [DefaultValue(0L)]
        public long VideoId { get; set; }

        /// <summary>
        /// Gets or sets the resolved data.
        /// </summary>
        [DefaultValue(null)]
        public EmbedData Data { get; set; }

        [NonSerialized]
        private Task<EmbedData> _FetchTask;

        /// <summary>
        /// A <see cref="DateTime"/>that an exception was thrown in <see cref="_FetchTask"/>.
        /// </summary>
        [NonSerialized]
        private DateTime _LastFaulted;

        /// <inheritdoc />
        public override Task<EmbedData> FetchAsync(RequestContext context)
        {
            lock (this)
            {
                if (_FetchTask?.Status == TaskStatus.Faulted
                    && DateTime.Now > _LastFaulted + context.Service.ErrorResponseCacheAge)
                {
                    _FetchTask = null;
                }

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

        private Task<EmbedData> FetchAsyncCore(RequestContext context)
            => context.ExecuteAsync(FetchOnceAsync).ContinueWith(t =>
            {
                _LastFaulted = t.IsFaulted ? DateTime.Now : default(DateTime);
                return t.Result;
            });

        /// <summary>
        /// Asynchronously returns embed data fetched from remote service without retries.
        /// </summary>
        /// <param name="context">The context of the request.</param>
        /// <returns>A task that represents the asynchronous fetch operation.</returns>
        private async Task<EmbedData> FetchOnceAsync(RequestContext context)
        {
            var hc = context.Service.HttpClient;

            var res = await hc.GetAsync($"http://ext.nicovideo.jp/api/getthumbinfo/sm" + VideoId).ConfigureAwait(false);
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }

            EmbedData d = null;
            EmbedData getOrCreate() => d ?? (d = new EmbedData());

            using (var s = await res.Content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var xr = XmlReader.Create(s))
            {
                while (xr.Read())
                {
                    if (xr.Depth == 2 && xr.NodeType == XmlNodeType.Element)
                    {
                        switch (xr.LocalName)
                        {
                            case "title":
                                getOrCreate().Title = xr.ReadElementContentAsString();
                                break;

                            case "description":
                                getOrCreate().Description = xr.ReadElementContentAsString();
                                break;

                            case "thumbnail_url":
                                getOrCreate().MetadataImage = new Media
                                {
                                    Thumbnail = new ImageInfo
                                    {
                                        Url = xr.ReadElementContentAsString()
                                    }
                                };
                                break;

                            case "watch_url":
                                getOrCreate().Url = xr.ReadElementContentAsString();
                                break;

                            case "user_id":
                                getOrCreate().AuthorUrl = $"http://www.nicovideo.jp/user/" + xr.ReadElementContentAsString();
                                break;

                            case "user_nickname":
                                getOrCreate().AuthorName = xr.ReadElementContentAsString();
                                break;
                        }
                    }
                }
            }

            return Data = (d?.Title == null ? null : d);
        }
    }
}
