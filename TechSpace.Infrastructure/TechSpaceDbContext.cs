using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TechSpace.Domain;

namespace TechSpace.Infrastructure
{
    public class TechSpaceDbContext : DbContext
    {
        public TechSpaceDbContext()
        {

        }
        public TechSpaceDbContext(DbContextOptions<TechSpaceDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<ProductionPremise> ProductionPremises { get; set; }
        public DbSet<TypeOfTechnologicalEquipment> TypeOfTechnologicalEquipment { get; set; }
        public DbSet<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
