using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Services.HotelService
{
    public class BookingHotelRoomService : IBookingHotelRoomService
    {
        private readonly BookingHotelRoomRepository _repository;

        public BookingHotelRoomService(BookingHotelRoomRepository repository)
        {
            _repository = repository;
        }

        public void AddBooking(BookingHotelRoom booking)
        {
            _repository.Insert(booking);
        }

        public void UpdateBooking(BookingHotelRoom booking)
        {
            _repository.Update(booking);
        }

        public void DeleteBooking(int id)
        {
            _repository.Delete(id);
        }

        public BookingHotelRoom GetBookingById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<BookingHotelRoom> GetAllBookings()
        {
            return _repository.GetAll();
        }

        public IEnumerable<BookingHotelRoom> GetBookingsByClientId(int clientId)
        {
            return _repository.GetBookingsByClientId(clientId);
        }

        public IEnumerable<BookingHotelRoom> GetAvailableBookings()
        {
            return _repository.GetAvailableRoom();
        }

        public IEnumerable<BookingHotelRoom> GetBookingsByClientId(string clientId)
        {
            throw new NotImplementedException();
        }
    }
}
