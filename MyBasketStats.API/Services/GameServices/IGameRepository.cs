using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Services.GameServices
{
    public interface IGameRepository
    {
        Task AddGameAsync(Game game);
    }
}
