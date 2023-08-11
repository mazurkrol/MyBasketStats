using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.DbContexts;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

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

        public async Task<(bool,TEntity?)> CheckIfIdExistsAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return (entity != null,entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
     

        public async Task<TEntity> GetByIdWithEagerLoadingAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.SingleOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }
    }
}
