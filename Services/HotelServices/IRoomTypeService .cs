using Models.Hotel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services.HotelService
{
    public interface IRoomTypeService
    {
        Task<ServiceResult> AddRoomTypeAsync(RoomType roomType);
        Task<ServiceResult> UpdateRoomTypeAsync(RoomType roomType);
        Task<ServiceResult> DeleteRoomTypeAsync(int id);
        Task<ServiceResult<RoomType>> GetRoomTypeByIdAsync(int id);
        Task<ServiceResult<IEnumerable<RoomType>>> GetAllRoomTypesAsync();
        Task<ServiceResult<IEnumerable<RoomType>>> GetRoomTypesByHotelIdAsync(int hotelId);
        Task<ServiceResult<IEnumerable<RoomType>>> GetExpensiveRoomTypesAsync(float priceThreshold);
    }
}
