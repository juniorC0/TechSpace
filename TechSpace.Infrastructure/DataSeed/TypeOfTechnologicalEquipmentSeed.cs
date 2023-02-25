using TechSpace.Domain;

namespace TechSpace.Infrastructure.DataSeed
{
    public class TypeOfTechnologicalEquipmentSeed
    {
        public static async Task Seed(TechSpaceDbContext dbContext)
        {
            if (!dbContext.TypeOfTechnologicalEquipment.Any())
            {
                var firstTypeOfTechnologicalEquipment = new TypeOfTechnologicalEquipment
                {
                    Code = "TTE1",
                    Name = "Type of Technological Equipment 1",
                    AreaOccupiedByEquipment = 50
                };

                var secondTypeOfTechnologicalEquipment = new TypeOfTechnologicalEquipment
                {
                    Code = "TTE2",
                    Name = "Type of Technological Equipment 2",
                    AreaOccupiedByEquipment = 100
                };

                var thirdTypeOfTechnologicalEquipment = new TypeOfTechnologicalEquipment
                {
                    Code = "TTE3",
                    Name = "Type of Technological Equipment 3",
                    AreaOccupiedByEquipment = 75
                };


                dbContext.TypeOfTechnologicalEquipment.Add(firstTypeOfTechnologicalEquipment);
                dbContext.TypeOfTechnologicalEquipment.Add(secondTypeOfTechnologicalEquipment);
                dbContext.TypeOfTechnologicalEquipment.Add(thirdTypeOfTechnologicalEquipment);


                await dbContext.SaveChangesAsync();
            }
        }
    }
}
