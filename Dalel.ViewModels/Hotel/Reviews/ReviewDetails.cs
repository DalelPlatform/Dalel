// File: Dalel.ViewModels.Hotel/ReviewDetails.cs
using System;

namespace Dalel.ViewModels
{
    public class ReviewDetails
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public int BookingHotelRoomId { get; set; }
        public int ClientId { get; set; }
    }
}
