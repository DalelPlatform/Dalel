using Models.Hotel;
using System.Collections.Generic;
using Utilities;

namespace Dalel.Services.HotelService
{
    public interface IHotelService
    {
        Task<ServiceResult> AddHotelAsync(Hotel hotel);
        Task<ServiceResult> UpdateHotelAsync(Hotel hotel);
        Task<ServiceResult> DeleteHotelAsync(int id);
        Task<ServiceResult<Hotel>> GetHotelByIdAsync(int id);
        Task<ServiceResult<IEnumerable<Hotel>>> GetAllHotelsAsync();
        Task<ServiceResult<IEnumerable<Hotel>>> GetHotelsByCityAsync(string city);
        Task<ServiceResult<Hotel>> GetHotelByOwnerIdAsync(string ownerId);
  
    }

}
