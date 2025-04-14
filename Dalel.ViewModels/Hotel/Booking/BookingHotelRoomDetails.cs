using System;
using System.Collections.Generic;

namespace Dalel.ViewModels
{
    public class BookingHotelRoomDetails
    {
        public int Id { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public decimal Price { get; set; }
        public int NumberOfGuests { get; set; }
        public string BookingStatus { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int? HotelId { get; set; }
        public string HotelName { get; set; }
        public string ClientId { get; set; }

        // Guest details returned with the booking
        public List<BookingGuestInRoomDetails> Guests { get; set; } = new List<BookingGuestInRoomDetails>();
    }

    public class BookingGuestInRoomDetails
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string NationalIDImage { get; set; }
    }
}
