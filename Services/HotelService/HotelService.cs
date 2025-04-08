
using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System.Collections.Generic;


namespace Dalel.Services.HotelService
{
    public class HotelService : IHotelService
    {
        private readonly HotelRepository _repository;

        public HotelService(HotelRepository repository)
        {
            _repository = repository;
        }

        public void AddHotel(Hotel hotel)
        {
            _repository.Insert(hotel);
        }

        public void UpdateHotel(Hotel hotel)
        {
            _repository.Update(hotel);
        }

        public void DeleteHotel(int id)
        {
            _repository.Delete(id);
        }

        public Hotel GetHotelById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Hotel> GetAllHotels()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Hotel> GetHotelsByCity(string city)
        {
            return _repository.GetHotelsByCity(city);
        }

        public Hotel GetHotelByOwnerId(string ownerId)
        {
            return _repository.GetHotelByOwnerId(ownerId);
        }
    }
}
