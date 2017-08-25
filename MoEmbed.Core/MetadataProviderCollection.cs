using System.Collections.Generic;
using System.Collections.ObjectModel;
using MoEmbed.Providers;

namespace MoEmbed
{
    /// <summary>
    /// Represents a list of <see cref="IMetadataProvider"/> attached to <see cref="MetadataService"/>.
    /// </summary>
    public sealed class MetadataProviderCollection : Collection<IMetadataProvider>
    {
        private readonly Dictionary<string, IMetadataProvider> _ProvidersByHost = new Dictionary<string, IMetadataProvider>();
        private readonly List<IMetadataProvider> _AnyHost = new List<IMetadataProvider>();

        /// <summary>
        /// Returns a sequence of providers that can handle the specified host.
        /// </summary>
        /// <param name="host">The host name to find.</param>
        /// <returns>The sequence of available providers.</returns>
        public IEnumerable<IMetadataProvider> GetByHost(string host)
        {
            for (; ; )
            {
                if (_ProvidersByHost.TryGetValue(host, out var mp))
                {
                    yield return mp;

                    break;
                }

                var i = host.IndexOf('.');
                if (i > 0 && host.IndexOf('.', i + 1) >= 0)
                {
                    host = host.Substring(i + 1);
                }
                else
                {
                    break;
                }
            }

            foreach (var mp in _AnyHost)
            {
                yield return mp;
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="MetadataProviderCollection"/>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="MetadataProviderCollection"/>.</param>
        public void AddRange(IEnumerable<IMetadataProvider> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <inheritdoc />
        protected override void InsertItem(int index, IMetadataProvider item)
        {
            MapItem(item);

            base.InsertItem(index, item);
        }

        /// <inheritdoc />
        protected override void RemoveItem(int index)
        {
            UnmapItem(this[index]);

            base.RemoveItem(index);
        }

        /// <inheritdoc />
        protected override void ClearItems()
        {
            _ProvidersByHost.Clear();
            _AnyHost.Clear();
            base.ClearItems();
        }

        /// <inheritdoc />
        protected override void SetItem(int index, IMetadataProvider item)
        {
            var old = this[index];
            if (old != item)
            {
                UnmapItem(old);
                MapItem(item);
                base.SetItem(index, item);
            }
        }

        private void MapItem(IMetadataProvider item)
        {
            if (item.SupportsAnyHost)
            {
                _AnyHost.Add(item);
            }
            else
            {
                foreach (var hn in item.GetSupportedHostNames())
                {
                    _ProvidersByHost.Add(hn, item);
                }
            }
        }

        private void UnmapItem(IMetadataProvider item)
        {
            if (item.SupportsAnyHost)
            {
                _AnyHost.Remove(item);
            }
            else
            {
                foreach (var hn in item.GetSupportedHostNames())
                {
                    _ProvidersByHost.Remove(hn);
                }
            }
        }
    }
}