using Microsoft.EntityFrameworkCore;
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

        public void DeleteAsync(int gameId)
        {
            var game = _context.Games
            .Include(g => g.HomeTeamGameStatsheet)
            .Include(g => g.RoadTeamGameStatsheet)
            .FirstOrDefault(g => g.Id == gameId);

            if (game != null)
            {
                // Delete related entities
                _context.RemoveRange(game.HomeTeamGameStatsheet);
                _context.RemoveRange(game.RoadTeamGameStatsheet);

                // Delete the main entity
                _context.Remove(game);

                // Save changes
                _context.SaveChanges();
            }
        }
    }
    
    
}
