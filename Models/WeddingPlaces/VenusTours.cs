using Models.WeddingPlaces.Enums;
namespace Models.WeddingPlaces
{
    public class VenusTours
    {
        public string Id { get; set; }
        public string VenueId { get; set; } // fk Venues.Id
        public string UserId { get; set; } // fk AspNetUser.Id
        public DateTime TourDate { get; set; }
        public TourStatus TourStatus { get; set; }
    }
}
