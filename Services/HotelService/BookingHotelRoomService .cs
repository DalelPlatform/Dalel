using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Services.HotelService
{
    public class BookingHotelRoomService 
    {
        private readonly BookingHotelRoomRepository _repository;

        public BookingHotelRoomService(BookingHotelRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task AddBookingAsync(BookingHotelRoom booking)
        {
            await _repository.InsertAsync(booking);
        }

        public async Task UpdateBookingAsync(BookingHotelRoom booking)
        {
            await _repository.UpdateAsync(booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<BookingHotelRoom> GetBookingByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BookingHotelRoom>> GetAllBookingsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<BookingHotelRoom>> GetBookingsByClientIdAsync(int clientId)
        {
            return await _repository.GetBookingsByClientIdAsync(clientId);
        }

        public async Task<IEnumerable<BookingHotelRoom>> GetAvailableBookingsAsync()
        {
            return await _repository.GetAvailableRoomAsync();
        }

        public async Task<IEnumerable<BookingHotelRoom>> GetBookingsByClientIdAsync(string clientId)
        {
            throw new NotImplementedException();
        }
    }
}
