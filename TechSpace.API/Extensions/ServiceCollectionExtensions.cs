using TechSpace.Application.Profiles;
using TechSpace.Infrastructure.Extensions;

namespace TechSpace.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(EquipmentPlacementContractProfile));
        }
    }
}
