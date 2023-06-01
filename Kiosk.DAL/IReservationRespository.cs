using Kiosk.DAL.DBModels;

namespace Kiosk.DAL
{
    public interface IReservationRespository
    {
        public Task<bool> CreateConcertBookingAsync(Reservation concert);
    }
}
