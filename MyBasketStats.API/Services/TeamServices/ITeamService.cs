using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.TeamServices
{
    public interface ITeamService : IBasicService<TeamDto,Team>
    {      

        Task<OperationResult<TeamDto>> AddTeamAsync(TeamForCreationDto team);
        Task<bool> CheckIfTeamExistsAsync(string name);
        Task AddPlayerToRosterAsync(Player player, Team team);


    }
}
