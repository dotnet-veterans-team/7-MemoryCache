using AnalizerDashboard.Infrastructure.Caching;
using AnalizerDashboard.Infrastructure.Caching.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace AnalizerDashboard.Configuration
{
    public static class MemoryCacheConfig
    {
        public static IServiceCollection AddCacheConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var children = configuration.GetSection("Caching").GetChildren();
            Dictionary<string, TimeSpan> configurationCache =
            children.ToDictionary(child => child.Key, child => TimeSpan.Parse(child.Value));

            services.AddMemoryCache();
            services.AddSingleton<ICacheStore>(x => new MemoryCacheStore(x.GetService<IMemoryCache>(), configurationCache));
            return services;
        }
    }
}
