using Models.Hotel;
using System.Collections.Generic;

namespace Dalel.Services.HotelService
{
    public interface IHotelService
    {
        void AddHotel(Hotel hotel);
        void UpdateHotel(Hotel hotel);
        void DeleteHotel(int id);
        Hotel GetHotelById(int id);
        IEnumerable<Hotel> GetAllHotels();
        IEnumerable<Hotel> GetHotelsByCity(string city);
        Hotel GetHotelByOwnerId(string ownerId);
    }
}
