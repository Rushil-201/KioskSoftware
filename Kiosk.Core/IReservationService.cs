using Kiosk.Core.DTO;
using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Core
{
    public interface IReservationService
    {
        /// <summary>
        /// Create reservation.
        /// </summary>
        /// <param name="createReservationDto"></param>
        /// <param name="paymentType"></param>
        /// <returns></returns>
        Task<ReservationDetailsResponse> CreateReservationAsync(CreateReservationDto createReservationDto, PaymentType paymentType);
    }
}
