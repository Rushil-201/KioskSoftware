using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Core.DTO
{
    public class CreateReservationDto
    {
        /// <summary>
        /// Id of booking history
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id of Concert
        /// </summary>
        public Guid ConcertId { get; set; }

        /// <summary>
        /// Name of person booking the tickets
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of person booking the tickets
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone Numbers.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Booking Date.
        /// </summary>
        public DateTime ReservationDate { get; set; }

        /// <summary>
        /// Id of Concert
        /// </summary>
        public double AmountPaid { get; set; }

        /// <summary>
        /// Number of seats booked
        /// </summary>
        public int NumberOfSeats { get; set; }

    }
}
