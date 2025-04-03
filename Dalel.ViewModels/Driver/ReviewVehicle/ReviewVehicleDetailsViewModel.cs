namespace Models.ViewModels
{
    public class ReviewVehicleDetailsViewModel
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public decimal Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public int BookingVehicleId { get; set; }
        public string ClientName { get; set; }
        public string VehicleDetails { get; set; }
    }
}
