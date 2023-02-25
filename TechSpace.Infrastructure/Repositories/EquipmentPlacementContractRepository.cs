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

        public new async Task AddAsync(EquipmentPlacementContract contract)
        {
            var isEnoughSpace = await IsEnoughSpaceInPremise(contract);

            if (contract.NumberOfEquipmentUnits == 0)
            {
                throw new Exception("You must specify the number of equipment units to be placed");
            }

            if (isEnoughSpace)
            {
                await _dbContext.EquipmentPlacementContracts.AddAsync(contract);
            }
            else
            {
                throw new Exception("Not enough space for new equipment");
            }
        }

        private async Task<bool> IsEnoughSpaceInPremise(EquipmentPlacementContract contract)
        {
            int occupiedArea = 0;

            var eagerLoadedContracts = await _dbContext.EquipmentPlacementContracts
                .Include(x => x.ProductionPremise.EquipmentPlacementContracts)
                .Include(x => x.TypeOfTechnologicalEquipment.EquipmentPlacementContracts)
                .Where(x => x.ProductionPremise.Code == contract.ProductionPremise.Code)
                .ToListAsync();

            if (eagerLoadedContracts.Count > 0)
            {
                foreach (var item in eagerLoadedContracts)
                {
                    occupiedArea = item.ProductionPremise.EquipmentPlacementContracts
                    .Where(x => x.ProductionPremise.Code == contract.ProductionPremise.Code)
                    .Sum(x => x.NumberOfEquipmentUnits * x.TypeOfTechnologicalEquipment.AreaOccupiedByEquipment);
                }
            }

            var requiredArea = contract.NumberOfEquipmentUnits * contract.TypeOfTechnologicalEquipment.AreaOccupiedByEquipment;

            if (contract.ProductionPremise.AvailableEquipmentPlacementArea < occupiedArea + requiredArea)
            {
                return false;
            }

            return true;
        }
    }
}
