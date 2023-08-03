using MyBasketStats.API.DbContexts;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Services.SeasonServices;

namespace MyBasketStats.API.Services.GameServices
{
    public class GameRepository : IGameRepository
    {
        private readonly MyBasketStatsContext _context;
        public GameRepository(MyBasketStatsContext context)
        {
            _context = context;
        }
        public async Task AddGameAsync(Game game)
        {
           await _context.Games.AddAsync(game);
           await _context.SaveChangesAsync();
        }
    }
    
    
}
