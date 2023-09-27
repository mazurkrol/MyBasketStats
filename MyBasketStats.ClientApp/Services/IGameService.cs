using MyBasketStats.ClientApp.Models;

namespace MyBasketStats.ClientApp.Services
{
    public interface IGameService
    {
        public Task TestAsync();
        public Task<GameDto> GetGame(int id);
    }
}
