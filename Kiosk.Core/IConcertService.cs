using Kiosk.Core.DTO;

namespace Kiosk.Core
{
    public interface IConcertService
    {
        Task<IEnumerable<ConcertDto>> GetUpcomingConcertsAsync();
    }
}
