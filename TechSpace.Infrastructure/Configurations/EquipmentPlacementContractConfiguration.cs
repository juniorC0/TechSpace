using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSpace.Domain;

namespace TechSpace.Infrastructure.Configurations
{
    public class EquipmentPlacementContractConfiguration : IEntityTypeConfiguration<EquipmentPlacementContract>
    {
        public void Configure(EntityTypeBuilder<EquipmentPlacementContract> builder)
        {
            //builder.Property(x => x.ProductionPremise).IsRequired();
            //builder.Property(x => x.TypeOfTechnologicalEquipment).IsRequired();
            //builder.Property(x => x.NumberOfEquipmentUnits).IsRequired();
        }
    }
}
