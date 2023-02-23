using TechSpace.Infrastructure;
using TechSpace.Infrastructure.DataSeed;

namespace TechSpace.API.Extensions
{
    public static class HostExtension
    {
        public static async Task SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<TechSpaceDbContext>();

                await SeedFacade.SeedData(context);
            }
        }
    }
}
