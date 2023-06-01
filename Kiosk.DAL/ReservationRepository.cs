using Kiosk.DAL.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Kiosk.DAL
{
    /// <summary>
    /// Handles booking Repository.
    /// </summary>
    public class ReservationRepository : IReservationRespository
    {
        private readonly KioskDbContext _context;
        private readonly ILogger<ReservationRepository> _logger;

        public ReservationRepository(KioskDbContext kioskDbContext, ILogger<ReservationRepository> logger)
        {
            _context = kioskDbContext;
            _logger = logger;
        }

        /// <summary>
        /// Create the booking for conert
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> CreateConcertBookingAsync(Reservation reservation)
        {
            _context.Reservation.Add(reservation);
            bool IsUpdated = false;
            int retryAttempt = 0;

            while (!IsUpdated)
            {
                try
                {
                    var concert = await _context.Concert.FirstOrDefaultAsync(c => c.Id == reservation.ConcertId);

                    if (concert != null && concert.AvailableCapacity >= reservation.NumberOfSeats)
                    {
                        concert.AvailableCapacity = concert.AvailableCapacity - reservation.NumberOfSeats;
                        _context.Concert.Update(concert);

                        var result = await _context.SaveChangesAsync();

                        return result > 0;
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    _logger.LogError(ex, ex.Message);
                    retryAttempt++;

                    if (retryAttempt >= 10)
                    {
                        return false;
                    }
                }
            }

            return false;
        }
    }
}
