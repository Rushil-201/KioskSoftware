using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.Models
{
    /// <summary>
    /// Payment Information
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Amount Received
        /// </summary>
        public double AmountReceived { get; set; }

        /// <summary>
        /// Payment Reference
        /// </summary>
        public string? PaymentReference { get; set; }
    }

    public enum PaymentType
    {
        Cash
    }
}
