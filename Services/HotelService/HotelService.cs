using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dalel.Services.HomeService
{
    public class HotelService 
    {
        private readonly HotelRepository _repository;

        public HotelService(HotelRepository repository)
        {
            _repository = repository;
        }

        public async Task AddHotel(Hotel hotel)
        {
            await _repository.InsertAsync(hotel);
        }

        public async Task UpdateHotel(Hotel hotel)
        {
            await _repository.UpdateAsync(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _repository.GetAllAsync();
        }

        public Task<IEnumerable<Hotel>> GetHotelsByCity(string city)
        {
            return _repository.GetHotelsByCityAsync(city); 
        }

        public Task<Hotel> GetHotelByOwnerId(string ownerId)
        {
            return _repository.GetHotelByOwnerIdAsync(ownerId); 
        }
    }
}
