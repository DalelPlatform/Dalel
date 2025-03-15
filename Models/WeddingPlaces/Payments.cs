using Models.WeddingPlaces.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WeddingPlaces
{
    public class Payments
    {
        public string Id { get; set; }
        public string BookingId { get; set; } // fk WeddingBookings.Id
        public PaymentMethod PaymentMethod { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string PaymentNote { get; set; }

    }
}
