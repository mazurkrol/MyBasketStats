using AutoMapper;

namespace MyBasketStats.API.Profiles
{
    public class ContractProfile : Profile
    {
        public ContractProfile() 
        {
            CreateMap<Entities.Contract, Models.ContractDto>();
        }
    }
}
