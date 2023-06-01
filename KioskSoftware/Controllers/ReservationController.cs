using Kiosk.Core;
using Kiosk.Core.DTO;
using Kiosk.Web.Model;
using KioskSoftware.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Kiosk.Web.Controllers
{
    /// <summary>
    /// Controller to handle booking related queries.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {

        /// <summary>
        /// Logger to reservation.
        /// </summary>
        private readonly ILogger<ConcertController> _logger;

        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ConcertController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }


        [HttpPost("/create")]
        [ProducesResponseType(typeof(IEnumerable<ConcertDto>), 200)]
        public async Task<IActionResult> CreateReservationAsync([FromBody] CreateReservationInput createReservationInput)
        {

            if(!TryValidateModel(createReservationInput))
            {
                throw new BadHttpRequestException("Please provide all the required details");
            }

            var reservationDetails = await _reservationService.CreateReservationAsync(new CreateReservationDto
            {
                Id = System.Guid.NewGuid(),
                ConcertId = createReservationInput.ConcertId,
                ReservationDate = DateTime.Now,
                Email = createReservationInput.Email,
                Name = createReservationInput.Name,
                PhoneNumber = createReservationInput.PhoneNumber,
                NumberOfSeats = createReservationInput.NumberOfSeats
            }, createReservationInput.PaymentType);

            return Ok(reservationDetails);
        }

    }
}
