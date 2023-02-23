using TechSpace.Domain;

namespace TechSpace.Application.Interfaces
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        Task AddAsync(T dto);
        Task<IEnumerable<T>> GetAllAsync();
        Task DeleteAsync(T dto);
        Task SaveChangesAsync();
    }
}
