using Kiosk.Models;
using System.ComponentModel.DataAnnotations;

namespace Kiosk.Web.Model
{
    /// <summary>
    /// Class for taking reservation input
    /// </summary>
    public class CreateReservationInput
    {
        /// <summary>
        /// Id of Concert
        /// </summary>
        [Required]
        public Guid ConcertId { get; set; }

        /// <summary>
        /// Name of person booking the tickets
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Name of person booking the tickets
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Phone Numbers.
        /// </summary>
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Number of seats booked
        /// </summary>
        [Required]
        [Range(1,2)]
        public int NumberOfSeats { get; set; }

        /// <summary>
        /// Payment Type
        /// </summary>
        public PaymentType PaymentType { get; set; }
    }
}
