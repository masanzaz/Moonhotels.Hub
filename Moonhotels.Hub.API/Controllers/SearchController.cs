using Microsoft.AspNetCore.Mvc;
using Moonhotels.Hub.Domain.Models.Hub;
using Moonhotels.Hub.Application.Features.SearchHotels.Queries;

namespace Moonhotels.Hub.API.Controllers
{
    [ApiVersion("1.0")]
    public class SearchController : BaseApiController
    {
        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        [HttpPost()]
        public async Task<ActionResult<HubSearchResponse>> Search([FromBody] HubSearchRequest hubSearchRequest)
        {
            try
            {
                return Ok(await Mediator.Send(new SearchHotelsQuery(hubSearchRequest)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred executing Search.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}