using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace TechSpace.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions));

            return services;
        }
    }
}
