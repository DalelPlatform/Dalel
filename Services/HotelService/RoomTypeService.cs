
using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System.Collections.Generic;


namespace Dalel.Services.HotelService
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly RoomTypeRepository _repository;

        public RoomTypeService(RoomTypeRepository repository)
        {
            _repository = repository;
        }

        public void AddRoomType(RoomType roomType)
        {
            _repository.Insert(roomType);
        }

        public void UpdateRoomType(RoomType roomType)
        {
            _repository.Update(roomType);
        }

        public void DeleteRoomType(int id)
        {
            _repository.Delete(id);
        }

        public RoomType GetRoomTypeById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<RoomType> GetAllRoomTypes()
        {
            return _repository.GetAll();
        }

        public IEnumerable<RoomType> GetRoomTypesByHotelId(int hotelId)
        {
            return _repository.GetRoomTypesByHotelId(hotelId);
        }

        public IEnumerable<RoomType> GetExpensiveRoomTypes(float priceThreshold)
        {
            return _repository.GetExpensiveRoomTypes(priceThreshold);
        }
    }
}
