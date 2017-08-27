using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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

            return Data = await Provider.FetchAsync(context.Service.HttpClient, Destination, Asin).ConfigureAwait(false);
        }
    }
}