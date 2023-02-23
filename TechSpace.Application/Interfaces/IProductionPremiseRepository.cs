using TechSpace.Domain;

namespace TechSpace.Application.Interfaces
{
    public interface IProductionPremiseRepository : IEntityRepository<ProductionPremise>
    {
        Task<ProductionPremise> GetByCodeAsync(string code);
    }
}
