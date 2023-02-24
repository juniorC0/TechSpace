using Microsoft.EntityFrameworkCore;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;
using TechSpace.Infrastructure.Repository;

namespace TechSpace.Infrastructure.Repositories
{
    public class ProductionPremiseRepository : EntityRepository<ProductionPremise>, IProductionPremiseRepository
    {
        private readonly TechSpaceDbContext _dbContext;


        public ProductionPremiseRepository(TechSpaceDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ProductionPremise> GetByCodeAsync(string code)
        {
            var productionPremice = await _dbContext.ProductionPremises
                .FirstOrDefaultAsync(x => x.Code == code);

            if (productionPremice is null)
            {
                throw new NullReferenceException("Can`t find this entity in DB");
            }

            return productionPremice;
        }
    }
}
