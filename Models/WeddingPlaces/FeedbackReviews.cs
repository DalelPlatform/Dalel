namespace Models.WeddingPlaces
{
    public class FeedbackReviews
    {
        public string Id { get; set; }
        public string venueId { get; set; } // fk Venues.Id
        public string UserId { get; set; } // fk Users.Id
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
