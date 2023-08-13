using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile() 
        {
            CreateMap<Models.TeamForCreationDto, Entities.Team>();
            CreateMap<Entities.Team, Models.TeamDto>();
            CreateMap<Entities.Team, Models.TeamWithPlayersDto>()
                .ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players));
        }
        
    }
}
