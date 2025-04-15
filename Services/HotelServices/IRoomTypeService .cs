using Models.Hotel;
using System.Collections.Generic;
using Utilities;

namespace Dalel.Services.HotelService
{
    public interface IRoomTypeService
    {
        ServiceResult AddRoomType(RoomType roomType);
        ServiceResult UpdateRoomType(RoomType roomType);
        ServiceResult DeleteRoomType(int id);
        ServiceResult<RoomType> GetRoomTypeById(int id);
        ServiceResult<IEnumerable<RoomType>> GetAllRoomTypes();
        ServiceResult<IEnumerable<RoomType>> GetRoomTypesByHotelId(int hotelId);
        ServiceResult<IEnumerable<RoomType>> GetExpensiveRoomTypes(float priceThreshold);
    }
}
