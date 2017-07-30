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

        private List<IMetadataProvider> _Providers;

        public List<IMetadataProvider> Providers
            => _Providers ?? (_Providers = new List<IMetadataProvider>());

        public MetadataService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MetadataService>();
        }

        public async Task<EmbedDataResult> GetDataAsync(ConsumerRequest request)
        {
            foreach (var prov in Providers)
            {
                var m = prov.GetMetadata(request);
                if (m != null)
                {
                    _logger.LogInformation("Selected Provider: {0}", prov);
                    var d = await m.FetchAsync();

                    if (d == null)
                    {
                        break;
                    }

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