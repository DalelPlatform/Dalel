using Models.Hotel;
using System.Collections.Generic;
using Utilities;

namespace Dalel.Services.HotelService
{
    public interface IBookingHotelRoomService
    {
        ServiceResult AddBooking(BookingHotelRoom booking);
        ServiceResult UpdateBooking(BookingHotelRoom booking);
        ServiceResult DeleteBooking(int id);
        ServiceResult<BookingHotelRoom> GetBookingById(int id);
        ServiceResult<IEnumerable<BookingHotelRoom>> GetAllBookings();
        ServiceResult<IEnumerable<BookingHotelRoom>> GetBookingsByClientId(string clientId);
        ServiceResult<IEnumerable<BookingHotelRoom>> GetAvailableBookings();
    }
}
