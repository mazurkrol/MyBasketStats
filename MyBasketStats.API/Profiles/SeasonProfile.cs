using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class SeasonProfile : Profile
    {
        public SeasonProfile() 
        {
            CreateMap<Entities.Season, Models.SeasonDto>().ForMember(dest => dest.GamesIds, opt => opt.MapFrom(src => src.Games.Select(cs => cs.Id).ToList()));
            CreateMap<Models.SeasonForCreationDto, Entities.Season>();
            CreateMap<Entities.ContractSeason, Models.SeasonDto>();
            
        }
        
    }
}
