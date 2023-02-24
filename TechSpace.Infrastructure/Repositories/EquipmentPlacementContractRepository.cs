using Microsoft.EntityFrameworkCore;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;
using TechSpace.Infrastructure.Repository;

namespace TechSpace.Infrastructure.Repositories
{
    public class EquipmentPlacementContractRepository : EntityRepository<EquipmentPlacementContract>, 
        IEquipmentPlacementContractRepository
    {
        private readonly TechSpaceDbContext _dbContext;

        public EquipmentPlacementContractRepository(TechSpaceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<IEnumerable<EquipmentPlacementContract>> GetAllAsync()
        {
            return await _dbContext.EquipmentPlacementContracts
                .Include(x => x.ProductionPremise)
                .Include(x => x.TypeOfTechnologicalEquipment)
                .Select(x => new EquipmentPlacementContract
                {
                    ProductionPremise = x.ProductionPremise,
                    TypeOfTechnologicalEquipment = x.TypeOfTechnologicalEquipment,
                    NumberOfEquipmentUnits = x.NumberOfEquipmentUnits
                }).ToListAsync();
        }
    }
}
