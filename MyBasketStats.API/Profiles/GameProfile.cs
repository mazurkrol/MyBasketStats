using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile() 
        {
            CreateMap<Models.GameForCreationDto, Entities.Game>();
            CreateMap<Entities.Game, Models.GameDto>();
            CreateMap<Entities.Game, Models.GameWithStatsheetsDto>()
                .ForMember(dest => dest.HomeTeamStatsheet, opt => opt.MapFrom(src => src.HomeTeamGameStatsheet))
                .ForMember(dest => dest.RoadTeamStatsheet, opt => opt.MapFrom(src => src.RoadTeamGameStatsheet));
        }
    }
}
