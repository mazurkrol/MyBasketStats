using MyBasketStats.API.Models;
using System.Linq.Expressions;

namespace MyBasketStats.API.Services.Basic
{
    public interface IBasicService<TDto, TEntity> where TDto : class where TEntity : class
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<(bool, TEntity?)> CheckIfIdExistsAsync(int id);
        Task<OperationResult<TDto>> DeleteByIdAsync(int id);
        Task<TEntity> GetEntityByIdAsync(int id);
        Task<TEntity> GetEntityByIdWithEagerLoadingAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
