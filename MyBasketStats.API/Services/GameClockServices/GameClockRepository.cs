using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.DbContexts;
using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Services.GameClockServices
{
    public class GameClockRepository : IGameClockRepository
    {
        private readonly MyBasketStatsContext _context;
        public GameClockRepository(MyBasketStatsContext context) 
        { 
            _context = context;
        }
        public async Task<Game> GetGameEntityAsync(int gameid)
        {
            return await _context.Games.FindAsync(gameid);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
