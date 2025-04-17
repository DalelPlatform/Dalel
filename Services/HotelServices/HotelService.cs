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

        public async Task<ServiceResult> AddHotelAsync(Hotel hotel)
        {
            try
            {
                await _hotelRepo.InsertAsync(hotel);
                await _hotelRepo.SaveAsync();
                return ServiceResult.SuccessResult("Hotel added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error adding hotel: " + ex.Message);
            }
        }

        public async Task<ServiceResult> UpdateHotelAsync(Hotel hotel)
        {
            try
            {
                await _hotelRepo.UpdateAsync(hotel);
                await _hotelRepo.SaveAsync();
                return ServiceResult.SuccessResult("Hotel updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating hotel: " + ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteHotelAsync(int id)
        {
            try
            {
                await _hotelRepo.DeleteAsync(id);
                await _hotelRepo.SaveAsync();
                return ServiceResult.SuccessResult("Hotel deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting hotel: " + ex.Message);
            }
        }

        public async Task<ServiceResult<Hotel>> GetHotelByIdAsync(int id)
        {
            try
            {
                var hotel = await _hotelRepo.GetByIdAsync(id);
                if (hotel == null)
                    return ServiceResult<Hotel>.FailureResult("Hotel not found.");
                return ServiceResult<Hotel>.SuccessResult(hotel, "Hotel retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<Hotel>.FailureResult("Error retrieving hotel: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<Hotel>>> GetAllHotelsAsync()
        {
            try
            {
                var hotels = await _hotelRepo.GetAllAsync();
                return ServiceResult<IEnumerable<Hotel>>.SuccessResult(hotels, "Hotels retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<Hotel>>.FailureResult("Error retrieving hotels: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<Hotel>>> GetHotelsByCityAsync(string city)
        {
            try
            {
                var hotels = await _hotelRepo.GetByConditionAsync(h => h.City == city && !h.IsDeleted);
                return ServiceResult<IEnumerable<Hotel>>.SuccessResult(hotels, "Hotels by city retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<Hotel>>.FailureResult("Error retrieving hotels by city: " + ex.Message);
            }
        }

        public async Task<ServiceResult<Hotel>> GetHotelByOwnerIdAsync(string ownerId)
        {
            try
            {
                var hotel = await _hotelRepo.GetHotelByOwnerIdAsync(ownerId);
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
