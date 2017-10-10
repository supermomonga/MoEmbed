using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MoEmbed.Providers;
using Portable.Xaml.Markup;

namespace MoEmbed.Models.Metadata
{
    /// <summary>
    /// Represents the <see cref="Metadata" /> for the URL of the Amazon.
    /// </summary>
    [Serializable]
    [ContentProperty(nameof(Data))]
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

        private async Task<EmbedData> FetchAsyncCore(RequestContext context)
        {
            _LastFaulted = default(DateTime);

            if (Provider == null || Destination == null || Asin == null)
            {
                return null;
            }
            try
            {
                return Data = await Provider.FetchAsync(context.Service.HttpClient, Destination, Asin).ConfigureAwait(false);
            }
            catch
            {
                _LastFaulted = DateTime.Now;
                throw;
            }
        }
    }
}