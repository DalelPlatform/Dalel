using System;
using System.Collections.Generic;
using System.Linq;
using Dalel.Repository.Hotel.Non_GenericRepository;
using Models.Hotel;
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

        public ServiceResult AddRoomType(RoomType roomType)
        {
            try
            {
                _roomTypeRepo.InsertAsync(roomType).GetAwaiter().GetResult();
                _roomTypeRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Room type added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error adding room type: " + ex.Message);
            }
        }

        public ServiceResult UpdateRoomType(RoomType roomType)
        {
            try
            {
                _roomTypeRepo.UpdateAsync(roomType).GetAwaiter().GetResult();
                _roomTypeRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Room type updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating room type: " + ex.Message);
            }
        }

        public ServiceResult DeleteRoomType(int id)
        {
            try
            {
                _roomTypeRepo.DeleteAsync(id).GetAwaiter().GetResult();
                _roomTypeRepo.SaveAsync().GetAwaiter().GetResult();
                return ServiceResult.SuccessResult("Room type deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting room type: " + ex.Message);
            }
        }

        public ServiceResult<RoomType> GetRoomTypeById(int id)
        {
            try
            {
                var roomType = _roomTypeRepo.GetByIdAsync(id).GetAwaiter().GetResult();
                if (roomType == null)
                    return ServiceResult<RoomType>.FailureResult("Room type not found.");
                return ServiceResult<RoomType>.SuccessResult(roomType, "Room type retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RoomType>.FailureResult("Error retrieving room type: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            try
            {
                var roomTypes = _roomTypeRepo.GetAllAsync().GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<RoomType>>.SuccessResult(roomTypes, "Room types retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<RoomType>>.FailureResult("Error retrieving room types: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<RoomType>> GetRoomTypesByHotelId(int hotelId)
        {
            try
            {
                var roomTypes = _roomTypeRepo.GetByConditionAsync(rt => rt.HotelId == hotelId).GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<RoomType>>.SuccessResult(roomTypes, "Room types by hotel retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<RoomType>>.FailureResult("Error retrieving room types by hotel: " + ex.Message);
            }
        }

        public ServiceResult<IEnumerable<RoomType>> GetExpensiveRoomTypes(float priceThreshold)
        {
            try
            {
                var roomTypes = _roomTypeRepo.GetByConditionAsync(rt => rt.Price > priceThreshold).GetAwaiter().GetResult();
                return ServiceResult<IEnumerable<RoomType>>.SuccessResult(roomTypes, "Expensive room types retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<RoomType>>.FailureResult("Error retrieving expensive room types: " + ex.Message);
            }
        }
    }
}
