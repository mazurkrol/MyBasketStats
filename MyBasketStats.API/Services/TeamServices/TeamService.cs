using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;
using System.Collections.Concurrent;

namespace MyBasketStats.API.Services.TeamServices
{
    public class TeamService : BasicService<TeamDto, Team, TeamDto>, ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(IMapper mapper, IBasicRepository<Team> basicRepository, ITeamRepository teamRepository) : base(mapper,basicRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<OperationResult<TeamDto>> AddTeamAsync(TeamForCreationDto team)
        {
            var teamToAdd = _mapper.Map<Team>(team);
            bool IsNameTaken = await CheckIfTeamExistsAsync(team.Name);

            if (IsNameTaken)
            {
                return new OperationResult<TeamDto>
                {
                    IsSuccess = false,
                    ErrorMessage = "Provided name is already taken.",
                    HttpResponseCode = 409
                };
            }
            else
            {
                await _teamRepository.AddTeamToDbAsync(teamToAdd);       
                var teamToReturn = _mapper.Map<TeamDto>(teamToAdd);
                return new OperationResult<TeamDto>
                {
                    IsSuccess = true,
                    Data = teamToReturn,
                    HttpResponseCode = 201
                };
            }
        }
        public async Task<bool> CheckIfTeamExistsAsync(string name)
        {
            var item = await _teamRepository.GetTeamByNameAsync(name);
            if (item == null) 
            { 
                return false;
            }
            else
            {
                return true;
            }
        }
        public async Task AddPlayerToRosterAsync(Player player, Team team)
        {
            await _teamRepository.AddPlayerAsync(player, team);
        }
        public async Task WaivePlayerAsync(Player player, Team team)
        {
            team.Players.Remove(player);
            await _basicRepository.SaveChangesAsync();
        }

    }
}
