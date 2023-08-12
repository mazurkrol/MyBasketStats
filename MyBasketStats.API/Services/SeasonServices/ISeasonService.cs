using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.SeasonServices
{
    public interface ISeasonService : IBasicService<SeasonDto, Season, SeasonDto>
    {
        Task<SeasonDto> AddSeasonAsync(SeasonForCreationDto season);
        Task AddGameToSeasonAsync(Game game);
        Task<bool> SeasonExistsAsync(int year);
        Task<Season> GetSeasonByYearAsync(int year);
    }
}
