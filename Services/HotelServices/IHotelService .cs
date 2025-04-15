using Models.Hotel;
using System.Collections.Generic;
using Utilities;

namespace Dalel.Services.HotelService
{
    public interface IHotelService
    {
        ServiceResult AddHotel(Hotel hotel);
        ServiceResult UpdateHotel(Hotel hotel);
        ServiceResult DeleteHotel(int id);
        ServiceResult<Hotel> GetHotelById(int id);
        ServiceResult<IEnumerable<Hotel>> GetAllHotels();
        ServiceResult<IEnumerable<Hotel>> GetHotelsByCity(string city);
        ServiceResult<Hotel> GetHotelByOwnerId(string ownerId);
    }
}
