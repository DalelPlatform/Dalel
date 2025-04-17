using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
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

        public async Task<ServiceResult> AddBookingAsync(BookingHotelRoom booking)
        {
            try
            {
                await _bookingRepo.InsertAsync(booking);
                await _bookingRepo.SaveAsync();
                return ServiceResult.SuccessResult("Booking added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error adding booking: " + ex.Message);
            }
        }

        public async Task<ServiceResult> UpdateBookingAsync(BookingHotelRoom booking)
        {
            try
            {
                await _bookingRepo.UpdateAsync(booking);
                await _bookingRepo.SaveAsync();
                return ServiceResult.SuccessResult("Booking updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating booking: " + ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteBookingAsync(int id)
        {
            try
            {
                await _bookingRepo.DeleteAsync(id);
                await _bookingRepo.SaveAsync();
                return ServiceResult.SuccessResult("Booking deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting booking: " + ex.Message);
            }
        }

        public async Task<ServiceResult<BookingHotelRoom>> GetBookingByIdAsync(int id)
        {
            try
            {
                var booking = await _bookingRepo.GetByIdAsync(id);
                if (booking == null)
                    return ServiceResult<BookingHotelRoom>.FailureResult("Booking not found.");

                return ServiceResult<BookingHotelRoom>.SuccessResult(booking, "Booking retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<BookingHotelRoom>.FailureResult("Error retrieving booking: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<BookingHotelRoom>>> GetAllBookingsAsync()
        {
            try
            {
                var bookings = await _bookingRepo.GetAllAsync();
                return ServiceResult<IEnumerable<BookingHotelRoom>>.SuccessResult(bookings, "Bookings retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<BookingHotelRoom>>.FailureResult("Error retrieving bookings: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<BookingHotelRoom>>> GetBookingsByClientIdAsync(string clientId)
        {
            try
            {
                var bookings = await _bookingRepo.GetByConditionAsync(b => b.ClientId == clientId);
                return ServiceResult<IEnumerable<BookingHotelRoom>>.SuccessResult(bookings, "Bookings for client retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<BookingHotelRoom>>.FailureResult("Error retrieving client bookings: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<BookingHotelRoom>>> GetAvailableBookingsAsync()
        {
            try
            {
                var bookings = await _bookingRepo.GetByConditionAsync(b => b.IsAvailable);
                return ServiceResult<IEnumerable<BookingHotelRoom>>.SuccessResult(bookings, "Available bookings retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<BookingHotelRoom>>.FailureResult("Error retrieving available bookings: " + ex.Message);
            }
        }
    }
}
