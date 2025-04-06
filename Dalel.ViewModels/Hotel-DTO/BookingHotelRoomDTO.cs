using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel_DTO
{
    public class BookingHotelRoomDTO
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public float Price { get; set; }
        public int NumberOfGuests { get; set; }
        public string BookingStatus { get; set; } // Enum can be mapped to string for simplicity
        public string ClientId { get; set; }
        public int RoomId { get; set; }
        public bool IsAvailable { get; set; }
        public PaymentHotelRoomDTO PaymentHotelRoom { get; set; }
        public ReviewHotelRoomDTO ReviewHotelRoom { get; set; }
    }

}
