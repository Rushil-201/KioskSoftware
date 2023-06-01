using Kiosk.Core.DTO;
using Kiosk.DAL;
using Kiosk.DAL.DBModels;
using Kiosk.Models;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Core
{
    /// <summary>
    /// Booking Service.
    /// </summary>
    public class ReservationService : IReservationService
    {
        private readonly IReservationService _reservationService;
        private readonly IReservationRespository _reservationRespository;
        private readonly Func<PaymentType, IPaymentHandler> _paymentHandler;
        private readonly KioskDbContext _kioskDbContext;

        public ReservationService(IReservationRespository reservationRespository, Func<PaymentType, IPaymentHandler> func, KioskDbContext kioskDbContext)
        {
            _reservationRespository = reservationRespository;
            _paymentHandler = func;
            _kioskDbContext = kioskDbContext;
        }

        /// <summary>
        /// Create Reserveration.
        /// </summary>
        /// <param name="createReservationDto"></param>
        /// <param name="paymentType"></param>
        /// <returns></returns>
        public async Task<ReservationDetailsResponse> CreateReservationAsync(CreateReservationDto createReservationDto, PaymentType paymentType)
        {
            
            var paymentHandler = _paymentHandler(paymentType);
            var payment = await paymentHandler.GetPaymentInfoAsync(createReservationDto);

            var isReserverationSuccess = await _reservationRespository.CreateConcertBookingAsync(new Reservation
            {
                Id = createReservationDto.Id,
                ReservationDate = createReservationDto.ReservationDate,
                AmountPaid = payment.AmountReceived,
                ConcertId = createReservationDto.ConcertId,
                Email = createReservationDto.Email,
                Name = createReservationDto.Name,
                NumberOfSeats = createReservationDto.NumberOfSeats,
                PhoneNumber = createReservationDto.PhoneNumber
            });

            if (!isReserverationSuccess)
            {
                throw new HttpRequestException("Reservation Failed. Please Try Again");
            }

            return new ReservationDetailsResponse
            {
                ReservationReferenceId = createReservationDto.Id,
                Name = createReservationDto.Name,
                ReservationDate = createReservationDto.ReservationDate,
                Email= createReservationDto.Email,
                NumberOfSeats= createReservationDto.NumberOfSeats,
                PhoneNumber= createReservationDto.PhoneNumber,
                AmountPaid = payment.AmountReceived
            };
        }
    }
}