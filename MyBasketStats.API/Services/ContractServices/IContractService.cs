using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.ContractServices
{
    public interface IContractService : IBasicService<ContractDto, Contract, ContractWithSeasonIdsDto>
    {
    }
}
