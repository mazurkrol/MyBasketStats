using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
namespace MyBasketStats.API.Services.TeamServices
{
    public interface ITeamService
    {
        Task<TeamDto> AddTeamAsync(TeamForCreationDto team);
        Task<bool> CheckIfTeamExistsAsync(string name);
        Task<TeamDto> GetTeamByIdAsync(int id);
    }
}
