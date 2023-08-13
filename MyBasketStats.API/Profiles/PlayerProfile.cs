using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile() 
        {
            CreateMap<Models.PlayerForCreationDto, Entities.Player>();
            CreateMap<Entities.Player, Models.PlayerDto>();
            CreateMap<Entities.Player, Models.PlayerWithStatsheetsDto>()
                .ForMember(dest => dest.SeasonalStatsheets, opt => opt.MapFrom(src => src.SeasonalStatsheets));
        }
    }
}
