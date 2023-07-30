using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class SeasonProfile : Profile
    {
        public SeasonProfile() 
        {
            CreateMap<Entities.Season, Models.SeasonDto>();
            CreateMap<Models.SeasonForCreationDto, Entities.Season>();
        }
        
    }
}
