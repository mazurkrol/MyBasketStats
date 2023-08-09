using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.SeasonServices
{
    public interface ISeasonRepository
    {
        Task AddSeasonToDbAsync(Season season);
        Task CreateSeasonalStatsheetsAsync(Season season);
        Task AddGameToSeasonAsync(Game game, int year);
        Task<bool> SeasonExistsAsync(int year);
        Task<Season> GetSeasonByYearAsync(int year);
    }
}
