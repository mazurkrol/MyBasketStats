using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.SeasonServices
{
    public interface ISeasonService : IBasicService<SeasonDto, Season>
    {
        Task<SeasonDto> AddSeasonAsync(SeasonForCreationDto season);
        Task AddGameToSeasonAsync(Game game);
        Task<bool> SeasonExistsAsync(int year);
    }
}
