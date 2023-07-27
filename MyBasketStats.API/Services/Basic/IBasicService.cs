using MyBasketStats.API.Models;

namespace MyBasketStats.API.Services.Basic
{
    public interface IBasicService<TDto, TEntity> where TDto : class where TEntity : class
    {
        Task<TDto> GetByIdAsync(int id);
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<(bool, TEntity?)> CheckIfIdExistsAsync(int id);
        Task<OperationResult<TDto>> DeleteByIdAsync(int id);
    }
}
