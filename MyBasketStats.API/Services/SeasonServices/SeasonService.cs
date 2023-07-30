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

        
    }
}
