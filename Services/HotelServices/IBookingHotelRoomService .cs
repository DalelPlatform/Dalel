using Models.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services.HotelService
{
    public interface IBookingHotelRoomService
    {
        Task<ServiceResult> AddBookingAsync(BookingHotelRoom booking);
        Task<ServiceResult> UpdateBookingAsync(BookingHotelRoom booking);
        Task<ServiceResult> DeleteBookingAsync(int id);
        Task<ServiceResult<BookingHotelRoom>> GetBookingByIdAsync(int id);
        Task<ServiceResult<IEnumerable<BookingHotelRoom>>> GetAllBookingsAsync();
        Task<ServiceResult<IEnumerable<BookingHotelRoom>>> GetBookingsByClientIdAsync(string clientId);
        Task<ServiceResult<IEnumerable<BookingHotelRoom>>> GetAvailableBookingsAsync();
    }
}
