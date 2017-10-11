using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using MoEmbed.Models.Mastodon;
using Newtonsoft.Json;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata" /> for the URL of the mastodon status.
    /// </summary>
    [Serializable]
    public sealed class MastodonMetadata : Metadata
    {
        /// <summary>
        /// Gets or sets the requested Host.
        /// </summary>
        [DefaultValue(null)]
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the status.
        /// </summary>
        [DefaultValue(0L)]
        public long StatusId { get; set; }

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

            var res = await hc.GetAsync($"https://{Host}/api/v1/statuses/{StatusId}").ConfigureAwait(false);
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }

            Status status;
            using (var s = await res.Content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var sr = new StreamReader(s))
            using (var jr = new JsonTextReader(sr))
            {
                status = new JsonSerializer().Deserialize<Status>(jr);
            }

            var d = new EmbedData()
            {
                ProviderName = Host,
                ProviderUrl = $"https://" + Host,

                AuthorName = status.Account.DisplayName,
                AuthorUrl = status.Account.Url,
                Title = $"{status.Account.DisplayName}(@{status.Account.UserName})",
                MetadataImage = new Media()
                {
                    Type = MediaTypes.Image,
                    RawUrl = status.Account.AvatarStatic,
                    RestrictionPolicy = RestrictionPolicies.Safe
                },
                RestrictionPolicy = status.IsSensitive ? RestrictionPolicies.Restricted : RestrictionPolicies.Unknown,
                Type = EmbedDataTypes.MixedContent,
                Url = status.Url,
            };

            foreach (var attachment in status.MediaAttachments)
            {
                var m = new Media()
                {
                    Location = attachment.TextUrl,
                    RawUrl = attachment.RemoteUrl ?? attachment.Url,
                    Type = attachment.Type == AttachmentType.Video
                            || attachment.Type == AttachmentType.Gifv ? MediaTypes.Video : MediaTypes.Image,
                    Thumbnail = new ImageInfo()
                    {
                        Url = attachment.PreviewUrl,
                        Width = attachment.Meta?.Small?.Width,
                        Height = attachment.Meta?.Small?.Height
                    }
                };

                d.Medias.Add(m);
            }

            try
            {
                var sb = new StringBuilder();

                using (var sr = new StringReader(status.Content))
                using (var xr = XmlReader.Create(sr, new XmlReaderSettings()
                {
                    ConformanceLevel = ConformanceLevel.Fragment
                }))
                {
                    while (xr.Read())
                    {
                        if (xr.Depth == 0 && xr.NodeType == XmlNodeType.Element)
                        {
                            using (var sub = xr.ReadSubtree())
                            {
                                var xe = XElement.Load(sub);

                                foreach (var n in xe.DescendantNodes())
                                {
                                    if (n.NodeType == XmlNodeType.Text)
                                    {
                                        sb.Append(((XText)n).Value);
                                    }
                                    else if (n.NodeType == XmlNodeType.Element)
                                    {
                                        var de = (XElement)n;

                                        if (de.Name.LocalName.Equals("br", StringComparison.OrdinalIgnoreCase))
                                        {
                                            sb.AppendLine();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    d.Description = sb.ToString();
                }
            }
            catch
            {
                d.Description = status.Content;
            }

            return Data = d;
        }
    }
}