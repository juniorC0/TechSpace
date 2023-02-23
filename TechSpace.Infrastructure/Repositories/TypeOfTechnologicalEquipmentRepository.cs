using Microsoft.EntityFrameworkCore;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;
using TechSpace.Infrastructure.Repository;

namespace TechSpace.Infrastructure.Repositories
{
    public class TypeOfTechnologicalEquipmentRepository : EntityRepository<TypeOfTechnologicalEquipment>,
        ITypeOfTechnologicalEquipmentRepository
    {
        private readonly TechSpaceDbContext _dbContext;


        public TypeOfTechnologicalEquipmentRepository(TechSpaceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<TypeOfTechnologicalEquipment> GetByCodeAsync(string code)
        {
            var typeOfTechnologicalEquipment = await _dbContext.TypeOfTechnologicalEquipment
                .FirstOrDefaultAsync(x => x.Code == code);

            if (typeOfTechnologicalEquipment is null)
            {
                throw new Exception("Can`t find this element is DB");
            }

            return typeOfTechnologicalEquipment;
        }
    }
}
