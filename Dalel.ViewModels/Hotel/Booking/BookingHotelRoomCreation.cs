using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class BookingHotelRoomCreation
    {
        [Required(ErrorMessage = "Room Id is required.")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Client Id is required.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Check-in date is required.")]
        public DateTime Checkin { get; set; }

        [Required(ErrorMessage = "Check-out date is required.")]
        public DateTime Checkout { get; set; }

        [Required(ErrorMessage = "Number of guests is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of guests must be at least 1.")]
        public int NumberOfGuests { get; set; }

        // Optional guest details
        public List<BookingGuestInRoomCreation> Guests { get; set; } = new List<BookingGuestInRoomCreation>();
    }

    public class BookingGuestInRoomCreation
    {
        [Required(ErrorMessage = "Guest full name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "National ID is required.")]
        public string NationalId { get; set; }

        public string NationalIDImage { get; set; }
    }
}
