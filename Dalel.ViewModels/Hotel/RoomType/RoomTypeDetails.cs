namespace Dalel.ViewModels
{
    public class RoomTypeDetails
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int MaxOccupancy { get; set; }
        public bool HasBreakfast { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBeds { get; set; }
        public float Price { get; set; }
        public int HotelId { get; set; }
        public List<string> RoomTypeImages { get; set; }
    }
}
