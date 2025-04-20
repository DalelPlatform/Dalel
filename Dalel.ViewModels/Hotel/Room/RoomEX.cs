using Dalel.ViewModels;
using Models.Hotel;
using System;

namespace Dalel.ViewModels.Extensions
{
    public static class RoomEx
    {
        // Maps from RoomCreation ViewModel to Room Model
        public static Room ToModel(this RoomCreation model)
        {
            if (model == null)
                return null;

            return new Room
            {
                RoomNumber = model.RoomNumber,
                RoomTypeId = model.RoomTypeID,
                Price = model.Price,
                BedType = model.BedType,
                ViewType = model.ViewType,
                Status = model.Status,
                IsActive = model.IsActive,
                Availability = Models.Enums.AvaliabilityStatus.Available // You can customize this logic as needed
            };
        }

        // Maps from Room model to RoomDetails ViewModel
        public static RoomDetails ToDetails(this Room room)
        {
            if (room == null)
                return null;

            return new RoomDetails
            {
                RoomID = room.Id,
                RoomNumber = room.RoomNumber,
                RoomTypeID = room.RoomTypeId,
                Price = room.Price,
                BedType = room.BedType,
                ViewType = room.ViewType,
                Status = room.Status,
                IsActive = room.IsActive
            };
        }

    
    }
}
