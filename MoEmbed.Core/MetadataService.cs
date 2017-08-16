using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MoEmbed.Models;
using MoEmbed.Providers;

namespace MoEmbed
{
    public class MetadataService
    {
        private readonly ILogger<MetadataService> _logger;
        private readonly IMetadataCache _Cache;

        private List<IMetadataProvider> _Providers;

        public MetadataService(ILoggerFactory loggerFactory, IMetadataCache cache = null)
        {
            _logger = loggerFactory.CreateLogger<MetadataService>();
            _Cache = cache;
        }

        public List<IMetadataProvider> Providers
            => _Providers ?? (_Providers = new List<IMetadataProvider>());

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
