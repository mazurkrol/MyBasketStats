using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.TeamServices;
using System.Runtime.CompilerServices;
using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/teams")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;


        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService=teamService ?? throw new ArgumentNullException(nameof(teamService));
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> GetTeams()
        {
            var teams= await _teamService.GetAllAsync();
            return Ok(teams);
        }
        [HttpGet("{teamid}",Name="GetTeam")]
        public async Task<ActionResult<TeamDto>> GetTeam(int teamid)
        {
            if(ModelState.IsValid)
            {
                var item = await _teamService.GetByIdAsync(teamid);
                if(item!=null)
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


    }
}
