using Models.WeddingPlaces.Enums;

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
