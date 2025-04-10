using Models.Hotel;
using System.Collections.Generic;


namespace Dalel.Services.HomeService
{
    public interface IRoomTypeService
    {
        void AddRoomType(RoomType roomType);
        void UpdateRoomType(RoomType roomType);
        void DeleteRoomType(int id);
        RoomType GetRoomTypeById(int id);
        IEnumerable<RoomType> GetAllRoomTypes();
        IEnumerable<RoomType> GetRoomTypesByHotelId(int hotelId);
        IEnumerable<RoomType> GetExpensiveRoomTypes(float priceThreshold);
    }
}
