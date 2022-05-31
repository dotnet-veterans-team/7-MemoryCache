namespace AnalizerDashboard.Infrastructure.Caching.Interfaces;

public interface ICacheKey<TItem>
{
    string CacheKey { get; }
    string CacheName { get; }
}

