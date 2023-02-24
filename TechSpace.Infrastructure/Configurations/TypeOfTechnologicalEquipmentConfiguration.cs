using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechSpace.Domain;

namespace TechSpace.Infrastructure.Configurations
{
    public class TypeOfTechnologicalEquipmentConfiguration : IEntityTypeConfiguration<TypeOfTechnologicalEquipment>
    {
        public void Configure(EntityTypeBuilder<TypeOfTechnologicalEquipment> builder)
        {
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.AreaOccupiedByEquipment).IsRequired();
        }
    }
}
