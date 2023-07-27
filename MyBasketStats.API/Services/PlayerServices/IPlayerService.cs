using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.PlayerServices
{
    public interface IPlayerService : IBasicService<PlayerDto, Player>
    {
        Task<PlayerDto> AddPlayerAsync(PlayerForCreationDto player);
        //Task<PlayerDto> GetTeamByIdAsync(int id);
    }
}
