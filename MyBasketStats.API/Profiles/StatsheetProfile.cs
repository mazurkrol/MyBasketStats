using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class StatsheetProfile : Profile
    {
        public StatsheetProfile() 
        {
            CreateMap<Entities.Statsheet, Models.StatsheetDto>();
        }
    }
}
