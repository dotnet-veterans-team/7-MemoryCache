using AnalizerDashboard.Infrastructure.Repository;
using AnalizerDashboard.Infrastructure.Repository.Interfaces;

namespace AnalizerDashboard.Configuration
{
    public static class MapConfig
    {
        public static IServiceCollection AddMapConfig(this IServiceCollection services)
        {
            services.AddScoped<IAnalistRepository, AnalistRepository>();
            services.AddScoped<ISampleRepository, SampleRepository>();
            return services;
        }
    }
}
