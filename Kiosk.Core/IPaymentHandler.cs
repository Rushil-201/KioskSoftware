using Kiosk.Core.DTO;
using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Core
{
    public interface IPaymentHandler
    {
        Task<Payment> GetPaymentInfoAsync(CreateReservationDto createReservationDto);
    }
}
