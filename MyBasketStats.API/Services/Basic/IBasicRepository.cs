namespace MyBasketStats.API.Services.Basic
{
    public interface IBasicRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<(bool,TEntity?)> CheckIfIdExistsAsync(int id);
        void DeleteAsync(TEntity entity);
        Task SaveChangesAsync();
    }
}
