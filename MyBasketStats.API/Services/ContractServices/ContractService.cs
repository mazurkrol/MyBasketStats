using AutoMapper;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;
namespace MyBasketStats.API.Services.ContractServices
{
    public class ContractService : BasicService<ContractDto,Contract,ContractWithSeasonIdsDto>, IContractService
    {
        public ContractService(IMapper mapper, IBasicRepository<Contract> basicRepository) : base(mapper, basicRepository)
        {

        }
        
    }
}
