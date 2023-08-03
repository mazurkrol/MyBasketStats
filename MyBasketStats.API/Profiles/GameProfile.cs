using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile() 
        {
            CreateMap<Models.GameForCreationDto, Entities.Game>();
            CreateMap<Entities.Game, Models.GameDto>();
        }
    }
}
