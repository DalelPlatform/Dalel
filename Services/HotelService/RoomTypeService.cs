using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dalel.Services
{
    public class RoomTypeService  
    {
        private readonly RoomTypeRepository _repository;

        public RoomTypeService(RoomTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task AddRoomType(RoomType roomType)
        {
            await _repository.InsertAsync(roomType);
        }

        public async Task UpdateRoomType(RoomType roomType)
        {
            await _repository.UpdateAsync(roomType);
        }

        public async Task DeleteRoomType(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<RoomType> GetRoomTypeById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await _repository.GetAllAsync();
        }

        public Task<IEnumerable<RoomType>> GetRoomTypesByHotelId(int hotelId)
        {
            return _repository.GetRoomTypesByHotelIdAsync(hotelId); 
        }

        public Task<IEnumerable<RoomType>> GetExpensiveRoomTypes(float priceThreshold)
        {
            return _repository.GetExpensiveRoomTypesAsync(priceThreshold); 
        }
    }
}
