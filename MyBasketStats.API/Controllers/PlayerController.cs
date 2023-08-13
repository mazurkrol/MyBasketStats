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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers()
        {
            var players = await _playerService.GetAllAsync();
            return Ok(players);
        }
        [HttpGet("{playerid}", Name = "GetPlayer")]
        public async Task<ActionResult<PlayerWithStatsheetsDto>> GetPlayer(int playerid)
        {
            if (ModelState.IsValid)
            {
                var item = await _playerService.GetExtendedByIdWithEagerLoadingAsync(playerid, c=>c.SeasonalStatsheets);
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

        [HttpPost("list", Name = "GetPlayersList")]
        public async Task<ActionResult<IEnumerable<PlayerWithStatsheetsDto>>> GetPlayersList(IEnumerable<int> ids)
        {
            var item = await _playerService.GetExtendedListWithEagerLoadingAsync(ids, c=> c.SeasonalStatsheets);
            if (item!=null)
            {
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{playertodeleteid}")]
        public async Task<ActionResult> DeletePlayer(int playertodeleteid)
        {
            var operationResult = await _playerService.DeleteByIdAsync(playertodeleteid);
            if (operationResult.IsSuccess)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(operationResult.HttpResponseCode, operationResult.ErrorMessage);
            }
        }



        [HttpPost]
        public async Task<ActionResult> AddPlayer(PlayerForCreationDto player)
        {
            if (ModelState.IsValid)
            {
                var createdPlayer = await _playerService.AddPlayerAsync(player);
                
                    return CreatedAtRoute("GetPlayer",
                new
                {
                    playerid = createdPlayer.Id
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
