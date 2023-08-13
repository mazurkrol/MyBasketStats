using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile() 
        {
            CreateMap<Entities.Contract, Models.ContractDto>();
            CreateMap<Entities.Contract, Models.ContractWithSeasonIdsDto>().ForMember(dest => dest.SeasonsIds, opt => opt.MapFrom(src => src.ContractSeasons.Select(cs => cs.SeasonId).ToList()));
        }
    }
}
