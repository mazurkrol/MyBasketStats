using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile() 
        {
            CreateMap<Entities.Contract, Models.ContractDto>().ForMember(dest => dest.SeasonsIds, opt => opt.MapFrom(src => src.ContractSeasons.Select(cs => cs.Season.Id).ToList()));
        }
    }
}
