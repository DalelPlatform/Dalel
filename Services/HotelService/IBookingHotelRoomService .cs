using Models.Hotel;
using System.Collections.Generic;

namespace Dalel.Services.HotelService
{
    public interface IBookingHotelRoomService
    {
        void AddBooking(BookingHotelRoom booking);
        void UpdateBooking(BookingHotelRoom booking);
        void DeleteBooking(int id);
        BookingHotelRoom GetBookingById(int id);
        IEnumerable<BookingHotelRoom> GetAllBookings();
        IEnumerable<BookingHotelRoom> GetBookingsByClientId(string clientId);
        IEnumerable<BookingHotelRoom> GetAvailableBookings();
    }
}
