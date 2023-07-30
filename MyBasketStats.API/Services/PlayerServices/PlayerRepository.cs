using MyBasketStats.API.DbContexts;
using MyBasketStats.API.Entities;
namespace MyBasketStats.API.Services.PlayerServices
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly MyBasketStatsContext _context;
        public PlayerRepository(MyBasketStatsContext context) 
        {
            _context = context;
        }
        public async Task AddPlayerToDbAsync(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync();
        }
        public async Task AddNewPlayerContract(Player player, Contract contract) 
        {
            player.Contract = contract;
            await _context.SaveChangesAsync();
        }
    }
}
