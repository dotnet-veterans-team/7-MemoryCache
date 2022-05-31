using AnalizerDashboard.Infrastructure.Caching.Interfaces;
using AnalizerDashboard.Models;

namespace AnalizerDashboard.Infrastructure.Caching
{
    public class AnalistCache : ICacheKey<Analist>
    {
        private readonly Guid _userId;
        private Analist analist;

        public AnalistCache(Guid userId)
        {
            _userId = userId;
        }

        public AnalistCache(Analist analist)
        {
            this.analist = analist;
        }

        public string CacheKey => $"Analist_{this._userId}";
        public string CacheName => $"Analist";
    }
}
