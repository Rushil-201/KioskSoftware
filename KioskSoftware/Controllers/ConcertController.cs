using Kiosk.Core;
using Kiosk.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace KioskSoftware.Controllers
{
    /// <summary>
    /// Controller to handle Concert related queries.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ConcertController : ControllerBase
    {
        /// <summary>
        /// Logger to Concert.
        /// </summary>
        private readonly ILogger<ConcertController> _logger;

        private readonly IConcertService _concertService;

        public ConcertController(ILogger<ConcertController> logger, IConcertService concertService)
        {
            _logger = logger;
            _concertService = concertService;
        }


        [HttpGet("/list")]
        [ProducesResponseType(typeof(IEnumerable<ConcertDto>), 200)]
        public async Task<IActionResult> GetUpcomingConcertsAsync()
        {

            var upcomingConcerts = await _concertService.GetUpcomingConcertsAsync();

            return Ok(upcomingConcerts);
        }
    }
}
