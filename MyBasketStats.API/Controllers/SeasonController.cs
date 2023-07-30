using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.SeasonServices;

namespace MyBasketStats.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/seasons")]
    public class SeasonController : ControllerBase
    {
        private readonly ISeasonService _seasonService;


        public SeasonController(ISeasonService seasonService, IMapper mapper)
        {
            _seasonService=seasonService ?? throw new ArgumentNullException(nameof(seasonService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeasonDto>>> GetSeasons()
        {
            var seasons = await _seasonService.GetAllAsync();
            return Ok(seasons);
        }
        [HttpGet("{seasonid}", Name = "GetSeason")]
        public async Task<ActionResult<SeasonDto>> GetSeason(int seasonid)
        {
            if (ModelState.IsValid)
            {
                var item = await _seasonService.GetByIdAsync(seasonid);
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

        [HttpDelete("{seasontodeleteid}")]
        public async Task<ActionResult> DeleteSeason(int seasontodeleteid)
        {
            var operationResult = await _seasonService.DeleteByIdAsync(seasontodeleteid);
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
        public async Task<ActionResult<SeasonDto>> CreateSeason(SeasonForCreationDto season)
        {
            if(ModelState.IsValid) 
            {
                var seasonToReturn = await _seasonService.AddSeasonAsync(season);

                return CreatedAtRoute("GetSeason",
                    new
                    {
                        seasonid = seasonToReturn.Id
                    },
                    seasonToReturn);
            }
            else
            { 
                return BadRequest(ModelState);
            }
        }
    }
}
