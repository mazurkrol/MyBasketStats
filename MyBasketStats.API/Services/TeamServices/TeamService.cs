using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
namespace MyBasketStats.API.Services.TeamServices
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        public TeamService(IMapper mapper, ITeamRepository teamRepository)
        {
            _mapper=mapper;
            _teamRepository=teamRepository;
        }

        public async Task<TeamDto> AddTeamAsync(TeamForCreationDto team)
        {
            var teamToAdd = _mapper.Map<Team>(team);
            bool IsNameTaken = await CheckIfTeamExistsAsync(team.Name);
            if (IsNameTaken) 
            {
                return null; 
            }
            else
            {
                await _teamRepository.AddTeamToDbAsync(teamToAdd);
                var teamToReturn = _mapper.Map<TeamDto>(teamToAdd);
                return teamToReturn;
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
        public async Task<TeamDto> GetTeamByIdAsync(int id)
        {
            var item = await _teamRepository.GetTeamByIdAsync(id);
            var itemToReturn = _mapper.Map<TeamDto>(item);
            return itemToReturn;
        }
    }
}
