using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using MoEmbed.Models;

namespace MoEmbed
{
    /// <summary>
    /// Provides in-memory cache to <see cref="MetadataService" />.
    /// </summary>
    public class MemoryMetadataCache : IMetadataCache
    {
        private readonly IMemoryCache _Cache;
        private readonly DistributedMetadataCache _Distributed;

        public MemoryMetadataCache(IMemoryCache cache, DistributedMetadataCache distributed = null)
        {
            _Cache = cache;
            _Distributed = distributed;
        }

        /// <summary>
        /// Reads the cached <see cref="Metadata" /> for the URL of <paramref name="request"/>.
        /// </summary>
        /// <param name="service">The <see cref="MetadataService" /> reading cache.</param>
        /// <param name="request">The consumer request.</param>
        /// <returns>The task object representing the asynchronous operation.
        /// The <see cref="Task{TResult}.Result"/> property on the task object returns a cached <see cref="Metadata"/>.</returns>
        public async Task<Metadata> ReadAsync(MetadataService service, ConsumerRequest request)
        {
            if (!_Cache.TryGetValue(request.Url, out Metadata r))
            {
                if (_Distributed != null)
                {
                    r = await _Distributed.ReadAsync(service, request).ConfigureAwait(false);

                    if (r != null)
                    {
                        _Cache.Set(request.Url, r, new MemoryCacheEntryOptions()
                        {
                            SlidingExpiration = TimeSpan.FromMinutes(60)
                        });
                    }
                }
            }

            return r;
        }

        public async Task WriteAsync(MetadataService service, ConsumerRequest request, Metadata metadata)
        {
            if (metadata == null)
            {
                _Cache.Remove(request.Url);
            }
            else
            {
                _Cache.Set(request.Url, metadata, new MemoryCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromMinutes(60)
                });
            }

            if (_Distributed != null)
            {
                await _Distributed.WriteAsync(service, request, metadata).ConfigureAwait(false);
            }
        }
    }
}