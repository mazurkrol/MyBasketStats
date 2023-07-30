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
            foreach(Player player in  _context.Players) 
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
    }
}
