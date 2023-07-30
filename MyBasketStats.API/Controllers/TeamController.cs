using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.TeamServices;
using System.Runtime.CompilerServices;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Services.PlayerServices;

namespace MyBasketStats.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/teams")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;


        public TeamController(ITeamService teamService, IMapper mapper, IPlayerService playerService)
        {
            _teamService=teamService ?? throw new ArgumentNullException(nameof(teamService));
            _playerService=playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            var teams = await _teamService.GetAllAsync();
            return Ok(teams);
        }
        [HttpGet("{teamid}", Name = "GetTeam")]
        public async Task<ActionResult<TeamDto>> GetTeam(int teamid)
        {
            if (ModelState.IsValid)
            {
                var item = await _teamService.GetByIdAsync(teamid);
                if (item!=null)
                {
                    return Ok(item);
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{teamtodeleteid}")]
        public async Task<ActionResult> DeleteTeam(int teamtodeleteid)
        {
            var operationResult = await _teamService.DeleteByIdAsync(teamtodeleteid);
            if (operationResult.IsSuccess)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(operationResult.HttpResponseCode, operationResult.ErrorMessage);
            }
        }

        [HttpPost("{playerid},{teamid}")]
        public async Task<ActionResult<ContractDto>> SignPlayerContract(ContractForCreationDto contract, int playerid, int teamid)
        {
            if (ModelState.IsValid)
            {
                (bool, Player?) playerExist = await _playerService.CheckIfIdExistsAsync(playerid);
                if (!playerExist.Item1)
                {
                    return NotFound($"Player with id={playerid} was not found.");
                }

                if (playerExist.Item2.TeamId != null)
                {
                    return StatusCode(403, $"Player with id={playerid} is already taken.");
                }

                (bool, Team?) teamExist = await _teamService.CheckIfIdExistsAsync(teamid);
                if (!teamExist.Item1)
                {
                    return NotFound($"Team with id={teamid} was not found.");
                }

                var operationResult = await _playerService.SignPlayerAsync(contract, playerExist.Item2, teamExist.Item2);

                if (operationResult.IsSuccess)
                {
                    await _teamService.AddPlayerToRosterAsync(playerExist.Item2, teamExist.Item2);
                    return Ok(operationResult.Data);
                }
                else
                {
                    return StatusCode(operationResult.HttpResponseCode, operationResult.ErrorMessage);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{playerid},{teamid}")]
        public async Task<ActionResult> WaivePlayer(int playerid, int teamid)
        {
            (bool, Player?) playerExist = await _playerService.CheckIfIdExistsAsync(playerid);
            if (!playerExist.Item1)
            {
                return NotFound($"Player with id={playerid} was not found.");
            }

            if (playerExist.Item2.TeamId != teamid)
            {
                return StatusCode(403, $"Player with id={playerid} is not a member of team with id={teamid}.");
            }

            (bool, Team?) teamExist = await _teamService.CheckIfIdExistsAsync(teamid);
            if (!teamExist.Item1)
            {
                return NotFound($"Team with id={teamid} was not found.");
            }
            await _teamService.WaivePlayerAsync(playerExist.Item2, teamExist.Item2);
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<TeamDto>> CreateTeam(TeamForCreationDto team)
        {
            
            if(ModelState.IsValid)
            {
               var operationResult = await _teamService.AddTeamAsync(team);
                if(operationResult.IsSuccess==true)
                {
                    return CreatedAtRoute("GetTeam",
                new
                {
                    teamid=operationResult.Data.Id
                },
                operationResult.Data
                );
                }
                else
                {
                    return StatusCode(operationResult.HttpResponseCode, operationResult.ErrorMessage);
                }
                
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        


    }
}
