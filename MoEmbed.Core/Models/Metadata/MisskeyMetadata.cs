using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MoEmbed.Models.Misskey;
using Newtonsoft.Json;
using Portable.Xaml.Markup;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata" /> for the URL of a Misskey note.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
    public sealed class MisskeyMetadata : Metadata
    {
        /// <summary>
        /// Gets or sets the host of the Misskey instance.
        /// </summary>
        [DefaultValue(null)]
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the note.
        /// </summary>
        [DefaultValue(null)]
        public string NoteId { get; set; }

        /// <summary>
        /// Gets or sets the resolved data.
        /// </summary>
        [DefaultValue(null)]
        public EmbedData Data { get; set; }

        [NonSerialized]
        private Task<EmbedData> _FetchTask;

        /// <summary>
        /// A <see cref="DateTime"/> that an exception was thrown in <see cref="_FetchTask"/>.
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

            var requestBody = JsonConvert.SerializeObject(new { noteId = NoteId });
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var res = await hc.PostAsync($"https://{Host}/api/notes/show", content).ConfigureAwait(false);
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }

            Note note;
            using (var s = await res.Content.ReadAsStreamAsync().ConfigureAwait(false))
            using (var sr = new StreamReader(s))
            using (var jr = new JsonTextReader(sr))
            {
                note = new JsonSerializer().Deserialize<Note>(jr);
            }

            var hasSensitiveFile = note.Files?.Any(f => f.IsSensitive) == true;

            var d = new EmbedData()
            {
                ProviderName = Host,
                ProviderUrl = $"https://{Host}",

                AuthorName = note.User.Name ?? note.User.Username,
                AuthorUrl = $"https://{Host}/@{note.User.Username}",
                Title = $"{note.User.Name ?? note.User.Username}(@{note.User.Username}@{Host})",
                Description = note.Cw ?? note.Text,
                MetadataImage = new Media()
                {
                    Type = MediaTypes.Image,
                    RawUrl = note.User.AvatarUrl,
                    RestrictionPolicy = RestrictionPolicies.Safe
                },
                RestrictionPolicy = hasSensitiveFile ? RestrictionPolicies.Restricted : RestrictionPolicies.Unknown,
                Url = $"https://{Host}/notes/{NoteId}",
            };

            if (note.Files != null)
            {
                foreach (var file in note.Files)
                {
                    var isVideo = file.Type?.StartsWith("video/") == true;
                    var m = new Media()
                    {
                        RawUrl = file.Url,
                        Type = isVideo ? MediaTypes.Video : MediaTypes.Image,
                        RestrictionPolicy = file.IsSensitive ? RestrictionPolicies.Restricted : RestrictionPolicies.Safe,
                        Thumbnail = file.ThumbnailUrl != null ? new ImageInfo()
                        {
                            Url = file.ThumbnailUrl,
                            Width = file.Properties?.Width,
                            Height = file.Properties?.Height
                        } : null
                    };

                    d.Medias.Add(m);
                }

                d.Type = note.Files.Length switch
                {
                    0 => EmbedDataTypes.MixedContent,
                    1 when note.Files[0].Type?.StartsWith("video/") == true => EmbedDataTypes.SingleVideo,
                    1 => EmbedDataTypes.SingleImage,
                    _ => EmbedDataTypes.MixedContent
                };
            }
            else
            {
                d.Type = EmbedDataTypes.MixedContent;
            }

            return Data = d;
        }
    }
}
