using AnalizerDashboard.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AnalizerDashboard.Configuration
{
    public static class DbConfig
    {
        public static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AnalizerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    });
            });
            return services;
        }
    }
}
