using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class TeamGameStatsheetProfile : Profile
    {
        public TeamGameStatsheetProfile() 
        {
            CreateMap<Entities.TeamGameStatsheet, Models.TeamGameStatsheetDto>();
        }
    }
}
