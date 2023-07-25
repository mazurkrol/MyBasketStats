using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile() 
        {
            CreateMap<Models.PlayerForCreationDto, Entities.Player>();
            CreateMap<Entities.Player, Models.PlayerDto>();
        }
    }
}
