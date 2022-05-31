using AnalizerDashboard.Infrastructure.Caching.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace AnalizerDashboard.Infrastructure.Caching
{
    public class MemoryCacheStore : ICacheStore
    {
        private readonly IMemoryCache _memoryCache;
        private List<string> _cacheNames;
        private readonly Dictionary<string, TimeSpan> _expirationConfiguration;

        public MemoryCacheStore(
            IMemoryCache memoryCache,
            Dictionary<string, TimeSpan> expirationConfiguration)
        {
            _memoryCache = memoryCache;
            _cacheNames = new List<string>();
            this._expirationConfiguration = expirationConfiguration;
        }

        public void Add<TItem>(TItem item, ICacheKey<TItem> key, TimeSpan? expirationTime = null)
        {
            var cachedObjectName = key.CacheName;
            TimeSpan timespan;
            if (expirationTime.HasValue)
            {
                timespan = expirationTime.Value;
            }
            else
            {
                timespan = _expirationConfiguration[cachedObjectName];
            }

            this._memoryCache.Set(key.CacheKey, item, timespan);
            _cacheNames.Add(key.CacheKey);
        }

        public void Clean()
        {
            var itemsToRemove = new List<string>(_cacheNames);
            itemsToRemove.ForEach(_memoryCache.Remove);
        }

        public TItem Get<TItem>(ICacheKey<TItem> key) where TItem : class
        {
            if (this._memoryCache.TryGetValue(key.CacheKey, out TItem value))
            {
                return value;
            }

            return null;
        }

        public void Remove<TItem>(ICacheKey<TItem> key)
        {
            this._memoryCache.Remove(key.CacheKey);
        }
    }
}
