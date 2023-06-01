using Kiosk.Core.DTO;
using Kiosk.DAL;
using Microsoft.EntityFrameworkCore;

namespace Kiosk.Core
{
    public class ConcertService : IConcertService
    {
        public readonly KioskDbContext _context;
        public ConcertService(KioskDbContext kioskDbContext)
        {
            _context = kioskDbContext;
        }

        public async Task<IEnumerable<ConcertDto>> GetUpcomingConcertsAsync()
        {
            var upcomingConcerts =  await _context.Concert.Where(x => x.PerformanceDateTime >= DateTime.Now).ToListAsync();

            return upcomingConcerts.Select(x => 
                new ConcertDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PerformanceDateTime = x.PerformanceDateTime,
                    AvailableCapacity = x.AvailableCapacity,
                    IsAvailable = x.IsAvailable && x.AvailableCapacity > 0,
                    Price = x.Price,
                    MaxCapacity = x.MaxCapacity
                });
        }
    }
}
