using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TechSpace.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TechSpaceDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("TechSpaceDb"));
            });

            return services;
        }
    }
}
