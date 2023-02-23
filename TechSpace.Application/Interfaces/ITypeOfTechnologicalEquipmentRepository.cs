using TechSpace.Domain;

namespace TechSpace.Application.Interfaces
{
    public interface ITypeOfTechnologicalEquipmentRepository : IEntityRepository<TypeOfTechnologicalEquipment>
    {
        Task<TypeOfTechnologicalEquipment> GetByCodeAsync(string code);
    }
}
