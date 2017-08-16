using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using MoEmbed.Models;
using MoEmbed.Models.Metadata;
using Portable.Xaml;

namespace MoEmbed
{
    /// <summary>
    /// Provides distributed cache to <see cref="MetadataService" />.
    /// </summary>
    public class DistributedMetadataCache : IMetadataCache
    {
        private readonly IDistributedCache _Cache;

        public DistributedMetadataCache(IDistributedCache cache)
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
        public async Task<Metadata> ReadAsync(MetadataService service, ConsumerRequest request)
        {
            var u = request.Url.ToString();
            var d = await _Cache.GetAsync(u).ConfigureAwait(false);
            if (d == null)
            {
                return null;
            }

            try
            {
                using (var ms = new MemoryStream(d))
                {
                    var r = (Metadata)XamlServices.Load(ms);
                    r.OnDeserialized(service);
                    return r;
                }
            }
            catch
            {
                try
                {
                    var t = _Cache.RemoveAsync(u);
                    t.GetHashCode();
                }
                catch { }

                return null;
            }
        }

        public async Task WriteAsync(MetadataService service, ConsumerRequest request, Metadata metadata)
        {
            var u = request.Url.ToString();
            if (metadata == null)
            {
                await _Cache.RemoveAsync(u).ConfigureAwait(false);
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    XamlServices.Save(ms, metadata);

                    await _Cache.SetAsync(u, ms.ToArray()).ConfigureAwait(false);
                }
            }
        }
    }
}