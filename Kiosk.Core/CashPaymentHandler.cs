using Kiosk.Core.DTO;
using Kiosk.DAL;
using Kiosk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Core
{
    public class CashPaymentHandler : IPaymentHandler
    {
        private readonly KioskDbContext _context;
        public CashPaymentHandler(KioskDbContext kioskDbContext)
        {
            _context = kioskDbContext;
        }

        public async Task<Payment> GetPaymentInfoAsync(CreateReservationDto createReservationDto)
        {
            var concert = await _context.Concert.FirstOrDefaultAsync(x => x.Id == createReservationDto.ConcertId);

            return new Payment
            {
                AmountReceived = createReservationDto.NumberOfSeats * concert?.Price ?? 1 
            };
        }
    }
}
