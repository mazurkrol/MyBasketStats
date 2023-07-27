using Microsoft.AspNetCore.Mvc;
using MyBasketStats.API.Services.PlayerServices;
using MyBasketStats.API.Services.TeamServices;
using MyBasketStats.API.Models;
using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        [HttpPost]
        public async Task<ActionResult> AddPlayer(PlayerForCreationDto player)
        {
            if (ModelState.IsValid)
            {
                var createdPlayer = await _playerService.AddPlayerAsync(player);
                
                    return CreatedAtRoute("GetTeam",
                new
                {
                    teamid = createdPlayer.Id
                },
                createdPlayer
                );
                
                

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        //[HttpGet("{playerid}",Name = "GetPlayer")]
        //public async Task<ActionResult> GetPlayer(int playerid)
        //{

        //}
    }
}
