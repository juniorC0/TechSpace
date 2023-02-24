using TechSpace.Domain;

namespace TechSpace.Infrastructure.DataSeed
{
    public class ProductionPremiseSeed
    {
        public static async Task Seed(TechSpaceDbContext dbContext)
        {
            if (!dbContext.ProductionPremises.Any())
            {
                var firstProductionPremice = new ProductionPremise
                {
                    Code = "PP1",
                    Name = "Production Premises 1",
                    AvailableEquipmentPlacementArea = 1000
                };

                var secondProductionPremice = new ProductionPremise
                {
                    Code = "PP2",
                    Name = "Production Premises 2",
                    AvailableEquipmentPlacementArea = 2000
                };

                var thirdProductionPremice = new ProductionPremise
                {
                    Code = "PP3",
                    Name = "Production Premises 3",
                    AvailableEquipmentPlacementArea = 1500
                };


                dbContext.ProductionPremises.Add(firstProductionPremice);
                dbContext.ProductionPremises.Add(secondProductionPremice);
                dbContext.ProductionPremises.Add(thirdProductionPremice);


                await dbContext.SaveChangesAsync();
            }
        }
    }
}
