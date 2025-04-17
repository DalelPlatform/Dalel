using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services.HotelService
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly RoomTypeRepository _roomTypeRepo;

        public RoomTypeService(RoomTypeRepository roomTypeRepo)
        {
            _roomTypeRepo = roomTypeRepo;
        }

        public async Task<ServiceResult> AddRoomTypeAsync(RoomType roomType)
        {
            try
            {
                await _roomTypeRepo.InsertAsync(roomType);
                await _roomTypeRepo.SaveAsync();
                return ServiceResult.SuccessResult("Room type added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error adding room type: " + ex.Message);
            }
        }

        public async Task<ServiceResult> UpdateRoomTypeAsync(RoomType roomType)
        {
            try
            {
                await _roomTypeRepo.UpdateAsync(roomType);
                await _roomTypeRepo.SaveAsync();
                return ServiceResult.SuccessResult("Room type updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating room type: " + ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteRoomTypeAsync(int id)
        {
            try
            {
                await _roomTypeRepo.DeleteAsync(id);
                await _roomTypeRepo.SaveAsync();
                return ServiceResult.SuccessResult("Room type deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting room type: " + ex.Message);
            }
        }

        public async Task<ServiceResult<RoomType>> GetRoomTypeByIdAsync(int id)
        {
            try
            {
                var roomType = await _roomTypeRepo.GetByIdAsync(id);
                if (roomType == null)
                    return ServiceResult<RoomType>.FailureResult("Room type not found.");
                return ServiceResult<RoomType>.SuccessResult(roomType, "Room type retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RoomType>.FailureResult("Error retrieving room type: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<RoomType>>> GetAllRoomTypesAsync()
        {
            try
            {
                var roomTypes = await _roomTypeRepo.GetAllAsync();
                return ServiceResult<IEnumerable<RoomType>>.SuccessResult(roomTypes, "Room types retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<RoomType>>.FailureResult("Error retrieving room types: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<RoomType>>> GetRoomTypesByHotelIdAsync(int hotelId)
        {
            try
            {
                var roomTypes = await _roomTypeRepo.GetByConditionAsync(rt => rt.HotelId == hotelId);
                return ServiceResult<IEnumerable<RoomType>>.SuccessResult(roomTypes, "Room types by hotel retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<RoomType>>.FailureResult("Error retrieving room types by hotel: " + ex.Message);
            }
        }

        public async Task<ServiceResult<IEnumerable<RoomType>>> GetExpensiveRoomTypesAsync(float priceThreshold)
        {
            try
            {
                var roomTypes = await _roomTypeRepo.GetByConditionAsync(rt => rt.Price > priceThreshold);
                return ServiceResult<IEnumerable<RoomType>>.SuccessResult(roomTypes, "Expensive room types retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<RoomType>>.FailureResult("Error retrieving expensive room types: " + ex.Message);
            }
        }
    }
}
