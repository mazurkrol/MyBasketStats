using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Services.PlayerServices
{
    public interface IPlayerRepository
    {
        Task AddPlayerToDbAsync(Player player);
        //Task<Player> GetPlayerBySurnameAsync(string name);
        //Task<Player> GetPlayerByIdAsync(int id);
    }
}
