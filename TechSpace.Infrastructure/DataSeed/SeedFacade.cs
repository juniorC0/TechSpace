using Microsoft.EntityFrameworkCore;

namespace TechSpace.Infrastructure.DataSeed
{
    public class SeedFacade
    {
        public static async Task SeedData(TechSpaceDbContext dbContext)
        {
            dbContext.Database.Migrate();

            await ProductionPremiseSeed.Seed(dbContext);
            await TypeOfTechnologicalEquipmentSeed.Seed(dbContext);
        }
    }
}
