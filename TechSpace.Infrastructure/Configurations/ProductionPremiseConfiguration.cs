using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSpace.Domain;

namespace TechSpace.Infrastructure.Configurations
{
    public class ProductionPremiseConfiguration : IEntityTypeConfiguration<ProductionPremise>
    {
        public void Configure(EntityTypeBuilder<ProductionPremise> builder)
        {
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.AvailableEquipmentPlacementArea).IsRequired();
        }
    }
}
