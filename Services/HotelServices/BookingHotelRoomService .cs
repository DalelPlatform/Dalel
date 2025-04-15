using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services.HotelService
{
    public class BookingHotelRoomService : IBookingHotelRoomService
    {
        private readonly BookingHotelRoomRepository _bookingRepo;

        public BookingHotelRoomService(BookingHotelRoomRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public ServiceResult AddBooking(BookingHotelRoom booking)
        {
            try
            {
                _bookingRepo.InsertAsync(booking).GetAwaiter().GetResult();
                _bookingRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Booking added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error adding booking: " + ex.Message);
            }
        }

        public ServiceResult UpdateBooking(BookingHotelRoom booking)
        {
            try
            {
                _bookingRepo.UpdateAsync(booking).GetAwaiter().GetResult();
                _bookingRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Booking updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating booking: " + ex.Message);
            }
        }

        public ServiceResult DeleteBooking(int id)
        {
            try
            {
                _bookingRepo.DeleteAsync(id).GetAwaiter().GetResult();
                _bookingRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Booking deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting booking: " + ex.Message);
            }
        }

        public ServiceResult<BookingHotelRoom> GetBookingById(int id)
        {
            try
            {
                var booking = _bookingRepo.GetByIdAsync(id).GetAwaiter().GetResult();
                if (booking == null)
                    return ServiceResult<BookingHotelRoom>.FailureResult("Booking not found.");

                return ServiceResult<BookingHotelRoom>.SuccessResult(booking, "Booking retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<BookingHotelRoom>.FailureResult("Error retrieving booking: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<BookingHotelRoom>> GetAllBookings()
        {
            try
            {
                var bookings = _bookingRepo.GetAllAsync().GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<BookingHotelRoom>>.SuccessResult(bookings, "Bookings retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<BookingHotelRoom>>.FailureResult("Error retrieving bookings: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<BookingHotelRoom>> GetBookingsByClientId(string clientId)
        {
            try
            {
                var bookings = _bookingRepo.GetByConditionAsync(b => b.ClientId == clientId).GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<BookingHotelRoom>>.SuccessResult(bookings, "Bookings for client retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<BookingHotelRoom>>.FailureResult("Error retrieving client bookings: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<BookingHotelRoom>> GetAvailableBookings()
        {
            try
            {
                var bookings = _bookingRepo.GetByConditionAsync(b => b.IsAvailable).GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<BookingHotelRoom>>.SuccessResult(bookings, "Available bookings retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<BookingHotelRoom>>.FailureResult("Error retrieving available bookings: " + ex.Message);
            }
        }
    }
}
