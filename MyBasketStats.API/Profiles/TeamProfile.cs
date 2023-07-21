using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile() 
        {
            CreateMap<Models.TeamForCreationDto, Entities.Team>();
            CreateMap<Entities.Team, Models.TeamDto>();
        }
        
    }
}
