using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.PlayerServices
{
    public interface IPlayerService : IBasicService<PlayerDto, Player, PlayerDto>
    {
        Task<PlayerDto> AddPlayerAsync(PlayerForCreationDto player);
        Task<OperationResult<ContractDto>> SignPlayerAsync(ContractForCreationDto contract, Player player, Team team);
        //Task<PlayerDto> GetTeamByIdAsync(int id);
    }
}
