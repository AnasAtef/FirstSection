using FirstSection.Contracts;
using FirstSection.Data;
using Microsoft.EntityFrameworkCore;
namespace FirstSection.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FitnessDbContext _context;

        public GenericRepository(FitnessDbContext context )
        {
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null) 
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(Guid? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;  // This was missing in your implementation
        }
    }
}
