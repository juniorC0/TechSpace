using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using TechSpace.Application.Interfaces;
using TechSpace.Infrastructure.Repository;
using TechSpace.Infrastructure.Repositories;

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

            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddScoped<IProductionPremiseRepository, ProductionPremiseRepository>();
            services.AddScoped<ITypeOfTechnologicalEquipmentRepository, TypeOfTechnologicalEquipmentRepository>();

            return services;
        }
    }
}
