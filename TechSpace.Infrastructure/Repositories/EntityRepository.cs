using Microsoft.EntityFrameworkCore;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;

namespace TechSpace.Infrastructure.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T:BaseEntity
    {
        private readonly TechSpaceDbContext _dbContext;


        public EntityRepository(TechSpaceDbContext dbContext )
        {
            _dbContext = dbContext;
        }


        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T dto)
        {
            var entity = await _dbContext.Set<T>().FindAsync(dto.Id);

            if (entity is null)
            {
                throw new NullReferenceException("Can`t find this element in db");
            }
            
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
