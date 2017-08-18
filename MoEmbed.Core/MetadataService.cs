using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.Extensions.Logging;
using MoEmbed.Models;
using MoEmbed.Providers;

namespace MoEmbed
{
    /// <summary>
    ///   Handles the request object and use right metadata handler to fetch embed data.
    /// </summary>
    public class MetadataService
    {
        private readonly ILogger<MetadataService> _logger;
        private readonly IMetadataCache _Cache;

        private List<IMetadataProvider> _Providers;

        /// <summary>
        ///   Initializes a new instance of the <see cref="MetadataService" /> class.
        /// </summary>
        public MetadataService(ILoggerFactory loggerFactory, IMetadataCache cache = null)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            _logger = loggerFactory.CreateLogger<MetadataService>();
            _Cache = cache;
        }

        /// <summary>
        ///   Gets the list of <see cref="IMetadataProvider" />.
        /// </summary>
        public List<IMetadataProvider> Providers
            => _Providers ?? (_Providers = new List<IMetadataProvider>());

        /// <summary>
        ///   Finds the right provider and use it to fetch embed data.
        /// </summary>
        public async Task<EmbedDataResult> GetDataAsync(ConsumerRequest request)
        {
            var m = _Cache == null ? null : await _Cache.ReadAsync(this, request).ConfigureAwait(false);
            if (m == null)
            {
                foreach (var prov in Providers)
                {
                    m = prov.GetMetadata(request);
                    if (m != null)
                    {
                        _logger?.LogInformation("Selected Provider: {0}", prov);

                        _Cache?.WriteAsync(this, request, m).ConfigureAwait(false);
                        break;
                    }
                }
            }

            if (m != null)
            {
                var d = await m.FetchAsync();

                if (d != null)
                {
                    return new EmbedDataResult()
                    {
                        Succeeded = true,
                        Data = d
                    };
                }
            }

            return new EmbedDataResult()
            {
                Succeeded = false,
                ErrorMessage = "Not Found"
            };
        }
    }
}
