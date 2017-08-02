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

        public MemoryMetadataCache(IMemoryCache cache)
        {
            _Cache = cache;
        }

        /// <summary>
        /// Reads the cached <see cref="Metadata" /> for the URL of <paramref name="request"/>.
        /// </summary>
        /// <param name="service">The <see cref="MetadataService" /> reading cache.</param>
        /// <param name="request">The consumer request.</param>
        /// <returns>The task object representing the asynchronous operation.
        /// The <see cref="Task{TResult}.Result"/> property on the task object returns a cached <see cref="Metadata"/>.</returns>
        public Task<Metadata> ReadAsync(MetadataService service, ConsumerRequest request)
        {
            _Cache.TryGetValue(request.Url, out Metadata r);
            return Task.FromResult(r);
        }

        public Task WriteAsync(MetadataService service, ConsumerRequest request, Metadata metadata)
        {
            _Cache.Set(request.Url, metadata, new MemoryCacheEntryOptions()
            {
                SlidingExpiration = TimeSpan.FromMinutes(60)
            });
            return Task.FromResult(0);
        }
    }
}