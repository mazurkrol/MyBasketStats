using MyBasketStats.API.Models;

namespace MyBasketStats.API.Services.PlayerServices
{
    public interface IPlayerService
    {
        Task<PlayerDto> AddPlayerAsync(PlayerForCreationDto player);
        //Task<PlayerDto> GetTeamByIdAsync(int id);
    }
}
