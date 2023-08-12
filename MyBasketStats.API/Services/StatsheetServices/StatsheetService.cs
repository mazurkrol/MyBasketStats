using AutoMapper;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;
using MyBasketStats.API.Services.TeamServices;

namespace MyBasketStats.API.Services.StatsheetServices
{
    public class StatsheetService : BasicService<StatsheetDto, Statsheet, StatsheetDto>, IStatsheetService
    {
        private readonly IStatsheetRepository _statsheetRepository;
        public StatsheetService(IMapper mapper, IBasicRepository<Statsheet> basicRepository, IStatsheetRepository statsheetRepository) : base(mapper, basicRepository)
        {
            _statsheetRepository = statsheetRepository;
        }
    }
}
