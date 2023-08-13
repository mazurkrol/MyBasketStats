using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.ContractServices;

namespace MyBasketStats.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/contracts")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;


        public ContractController(IContractService contractService, IMapper mapper)
        {
            _contractService=contractService ?? throw new ArgumentNullException(nameof(contractService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDto>>> GetContracts()
        {
            var contracts = await _contractService.GetAllAsync();
            return Ok(contracts);
        }
        [HttpGet("{contractid}", Name = "GetContract")]
        public async Task<ActionResult<ContractWithSeasonIdsDto>> GetContract(int contractid)
        {
            if (ModelState.IsValid)
            {
                var item = await _contractService.GetExtendedByIdWithEagerLoadingAsync(contractid, c => c.ContractSeasons);
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

        [HttpDelete("{contracttodeleteid}")]
        public async Task<ActionResult> DeleteContract(int contracttodeleteid)
        {
            var operationResult = await _contractService.DeleteByIdAsync(contracttodeleteid);
            if (operationResult.IsSuccess)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(operationResult.HttpResponseCode, operationResult.ErrorMessage);
            }
        }
    }
}
