using System;
using System.Collections.Generic;
using System.Linq;
using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using Utilities;

namespace Dalel.Services.HotelService
{
    public class HotelService : IHotelService
    {
        private readonly HotelRepository _hotelRepo;

        public HotelService(HotelRepository hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }

        public ServiceResult AddHotel(Hotel hotel)
        {
            try
            {
                _hotelRepo.InsertAsync(hotel).GetAwaiter().GetResult();
                _hotelRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Hotel added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error adding hotel: " + ex.Message);
            }
        }

        public ServiceResult UpdateHotel(Hotel hotel)
        {
            try
            {
                _hotelRepo.UpdateAsync(hotel).GetAwaiter().GetResult();
                _hotelRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Hotel updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating hotel: " + ex.Message);
            }
        }

        public ServiceResult DeleteHotel(int id)
        {
            try
            {
                _hotelRepo.DeleteAsync(id).GetAwaiter().GetResult();
                _hotelRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Hotel deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting hotel: " + ex.Message);
            }
        }

        public ServiceResult<Hotel> GetHotelById(int id)
        {
            try
            {
                var hotel = _hotelRepo.GetByIdAsync(id).GetAwaiter().GetResult();
                if (hotel == null)
                    return ServiceResult<Hotel>.FailureResult("Hotel not found.");
                return ServiceResult<Hotel>.SuccessResult(hotel, "Hotel retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Hotel>.FailureResult("Error retrieving hotel: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<Hotel>> GetAllHotels()
        {
            try
            {
                var hotels = _hotelRepo.GetAllAsync().GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<Hotel>>.SuccessResult(hotels, "Hotels retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<Hotel>>.FailureResult("Error retrieving hotels: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<Hotel>> GetHotelsByCity(string city)
        {
            try
            {
                var hotels = _hotelRepo.GetByConditionAsync(h => h.City == city && !h.IsDeleted).GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<Hotel>>.SuccessResult(hotels, "Hotels by city retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<Hotel>>.FailureResult("Error retrieving hotels by city: " + ex.Message);
            }
        }

        public ServiceResult<Hotel> GetHotelByOwnerId(string ownerId)
        {
            try
            {
                var hotel = _hotelRepo.GetHotelByOwnerIdAsync(ownerId).GetAwaiter().GetResult();
                if (hotel == null)
                    return ServiceResult<Hotel>.FailureResult("Hotel for the owner not found.");
                return ServiceResult<Hotel>.SuccessResult(hotel, "Hotel by owner retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Hotel>.FailureResult("Error retrieving hotel by owner: " + ex.Message);
            }
        }
    }
}
