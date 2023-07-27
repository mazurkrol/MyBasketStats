using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.DbContexts;

namespace MyBasketStats.API.Services.Basic
{
    public class BasicRepository<TEntity> : IBasicRepository<TEntity> where TEntity : class
    {

        private readonly MyBasketStatsContext _context;
        public BasicRepository(MyBasketStatsContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}
