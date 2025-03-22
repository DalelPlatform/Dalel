using Models.Enums;

namespace Models.WeddingPlaces
{
    class WeddingBookings
    {
        public string Id { get; set; }
        public string VenueId { get; set; } // fk Venues.Id
        public string UserId { get; set; } // fk AspNetUser.Id
        public DateTime BookingDate { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public string BookingNote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public float TotalAmount { get; set; }
        public float DebositAmount { get; set; }
    }
}
