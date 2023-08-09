using AutoMapper;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.SeasonServices
{
    public class SeasonService : BasicService<SeasonDto, Season>, ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonService(IMapper mapper, IBasicRepository<Season> basicRepository, ISeasonRepository seasonRepository) : base(mapper, basicRepository)
        {
            _seasonRepository=seasonRepository;
        }

        public async Task<SeasonDto> AddSeasonAsync(SeasonForCreationDto season)
        {
            var seasonToAdd = _mapper.Map<Season>(season);

            await _seasonRepository.AddSeasonToDbAsync(seasonToAdd);
            await _seasonRepository.CreateSeasonalStatsheetsAsync(seasonToAdd);
            var seasonToReturn = _mapper.Map<SeasonDto>(seasonToAdd);
            return seasonToReturn;
        }

        public async Task AddGameToSeasonAsync(Game game)
        {
            await _seasonRepository.AddGameToSeasonAsync(game, game.Date.Year);           
        }

        public async Task<bool> SeasonExistsAsync(int year)
        {
            return await _seasonRepository.SeasonExistsAsync(year);
        }

        public async Task<Season> GetSeasonByYearAsync(int year)
        {
            return await _seasonRepository.GetSeasonByYearAsync(year);
        }
    }
}
