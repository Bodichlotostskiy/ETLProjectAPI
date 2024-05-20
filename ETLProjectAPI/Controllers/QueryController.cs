using ETLProjectAPI.Services.Data;
using ETLProjectAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ETLProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService _queryService;

        public QueryController(IQueryService queryService)
        {
            _queryService = queryService;
        }

        [HttpGet("highest-tip")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<HighestTipLocation>))]
        public async Task<IActionResult> GetHighestTipLocation()       

        {
            return Ok(await _queryService.GetHighestTipLocation());
        }

        [HttpGet("top-100-longest-fares")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaxiTripDTO>))]
        public async Task<IActionResult> GetTop100LongestFares()
        {
            return Ok(await _queryService.GetTop100LongestFares());
        }

        [HttpGet("top-100-longest-time")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaxiTripDTO>))]
        public async Task<IActionResult> GetTop100LongestTime()
        {
            return Ok(await _queryService.GetTop100LongestTime());
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaxiTripDTO>))]
        public async Task<IActionResult> SearchByPULocationId([FromQuery] int pULocationId)
        {
            return Ok(await _queryService.SearchByPULocationId(pULocationId));
        }
    }
}
