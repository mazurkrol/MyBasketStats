using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.DictionaryServices;
using MyBasketStats.API.Services.GameClockServices;
using MyBasketStats.API.Services.GameServices;
using MyBasketStats.API.Services.SeasonServices;
using System;
using System.Security.Policy;

namespace MyBasketStats.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ISeasonService _seasonService;
        private readonly IGameClockService _gameClockService;
        private readonly IDictionaryService _dictionaryService;
        public GameController(IGameService gameService, ISeasonService seasonService, IGameClockService gameClockService, IDictionaryService dictionaryService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
            _seasonService = seasonService ?? throw new ArgumentNullException(nameof(seasonService));
            _gameClockService = gameClockService ?? throw new ArgumentNullException(nameof(gameClockService));
            _dictionaryService = dictionaryService ?? throw new ArgumentNullException(nameof(dictionaryService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGames()
        {
            var games = await _gameService.GetAllAsync();
            return Ok(games);
        }
        [HttpGet("{gameid}", Name = "GetGame")]
        public async Task<ActionResult<GameWithStatsheetsDto>> GetGame(int gameid)
        {
            if (ModelState.IsValid)
            {
                var item = await _gameService.GetExtendedByIdWithEagerLoadingAsync(gameid);
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

        [HttpDelete("{gametodeleteid}")]
        public async Task<ActionResult> DeleteGame(int gametodeleteid)
        {
            var operationResult = await _gameService.DeleteByIdAsync(gametodeleteid);
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
        public async Task<ActionResult> AddGame(GameForCreationDto game)
        {
            if(ModelState.IsValid)
            {
                game.Date = TimeZoneInfo.ConvertTimeToUtc(game.Date);
                if (game.Date<DateTime.Now)
                {
                    return StatusCode(422, "Past games are not accepted.");
                }
                var result = await _seasonService.SeasonExistsAsync(game.Date.Year);
                if(!result)
                {
                    return StatusCode(422, $"Season with Year={game.Date.Year} doesn't exist yet.");
                }

                var gameToReturn = await _gameService.CreateGameAsync(game);
                await _seasonService.AddGameToSeasonAsync(gameToReturn.Item2);
                return CreatedAtRoute("GetGame",
                new
                {
                    gameid = gameToReturn.Item1.Id
                },
                gameToReturn.Item1
                );
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("live/{gameid}/start")]
        public async Task<ActionResult<GameDto>> StartGame(int gameid)
        {
            var result = await _gameService.StartGameAsync(gameid);
            if(result.IsSuccess) 
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
            
        }

        [HttpPost("live/{gameid}/finish")]
        public async Task<ActionResult<GameDto>> FinishGame(int gameid)
        {
            var result = await _gameService.FinishGameAsync(gameid);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }

        }

        [HttpPost("live/{gameid}/clock/start")]
        public async Task<ActionResult> StartGameClock(int gameid)
        {
            var result = await _gameService.StartGameClock(gameid);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
                       
        }

        [HttpPost("live/{gameid}/clock/stop")]
        public async Task<ActionResult> StopGameClock(int gameid)
        {
            var result = await _gameService.StopGameClock(gameid);
            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/clock/add/{seconds}")]
        public async Task<ActionResult> AddSecondsElapsed(int gameid, int seconds)
        {
           var result = await _gameService.AddElapsedSecondsAsync(gameid, seconds);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/clock/subtract/{seconds}")]
        public async Task<ActionResult<GameDto>> SubtractSecondsElapsed(int gameid, int seconds)
        {
            var result = await _gameService.SubtractElapsedSecondsAsync(gameid, seconds);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/3pointer/{teamid}/{playerid}/{issuccessful}")]
        public async Task<ActionResult<GameDto>> ThreePointerAttempt(int gameid, int teamid, int playerid, bool issuccessful)
        {
            var result = await _gameService.ThreePointerAttemptAsync(gameid, playerid, teamid, issuccessful);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/2pointer/{teamid}/{playerid}/{issuccessful}")]
        public async Task<ActionResult<GameDto>> TwoPointerAttempt(int gameid, int teamid, int playerid, bool issuccessful)
        {
            var result = await _gameService.TwoPointerAttemptAsync(gameid, playerid, teamid, issuccessful);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/freethrow/{teamid}/{playerid}/{issuccessful}")]
        public async Task<ActionResult<GameDto>> FreeThrowAttempt(int gameid, int teamid, int playerid, bool issuccessful)
        {
            var result = await _gameService.FreeThrowAttemptAsync(gameid, playerid, teamid, issuccessful);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/block/{teamid}/{playerid}")]
        public async Task<ActionResult<GameDto>> Block(int gameid, int teamid, int playerid)
        {
            var result = await _gameService.BlockAsync(gameid, playerid, teamid);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/assist/{teamid}/{playerid}")]
        public async Task<ActionResult<GameDto>> Assist(int gameid, int teamid, int playerid)
        {
            var result = await _gameService.AssistAsync(gameid, playerid, teamid);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/rebound/{teamid}/{playerid}")]
        public async Task<ActionResult<GameDto>> Rebound(int gameid, int teamid, int playerid)
        {
            var result = await _gameService.ReboundAsync(gameid, playerid, teamid);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/steal/{teamid}/{playerid}")]
        public async Task<ActionResult<GameDto>> Steal(int gameid, int teamid, int playerid)
        {
            var result = await _gameService.StealAsync(gameid, playerid, teamid);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/turnover/{teamid}/{playerid}")]
        public async Task<ActionResult<GameDto>> Turnover(int gameid, int teamid, int playerid)
        {
            var result = await _gameService.TurnoverAsync(gameid, playerid, teamid);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }

        [HttpPost("live/{gameid}/foul/{teamid}/{playerid}")]
        public async Task<ActionResult<GameDto>> Foul(int gameid, int teamid, int playerid)
        {
            var result = await _gameService.FoulAsync(gameid, playerid, teamid);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            else
            {
                return StatusCode(result.HttpResponseCode, result.ErrorMessage);
            }
        }
    }
}
