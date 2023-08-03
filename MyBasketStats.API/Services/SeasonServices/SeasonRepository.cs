using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.DbContexts;
using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Services.SeasonServices
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly MyBasketStatsContext _context;
        public SeasonRepository(MyBasketStatsContext context)
        {
            _context = context;
        }
        public async Task CreateSeasonalStatsheetsAsync(Season season)
        {
            foreach (Player player in _context.Players)
            {
                player.SeasonalStatsheets.Add(
                    new Statsheet()
                    {
                        Season = season
                    }
                    );
            }
            await _context.SaveChangesAsync();
        }
        public async Task AddSeasonToDbAsync(Season season)
        {
            await _context.Seasons.AddAsync(season);
            await _context.SaveChangesAsync();
        }

        public async Task AddGameToSeasonAsync(Game game, int year)
        {
            var season = await _context.Seasons
                .Where(c => c.Year == year)
                .FirstOrDefaultAsync();
            season.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SeasonExistsAsync(int year)
        {
            return await _context.Seasons
                .Where(c => c.Year == year)
                .AnyAsync();
        }
    }
}
