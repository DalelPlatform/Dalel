using Dalel.ViewModels;
using Models.Hotel;
using System;

namespace Dalel.ViewModels
{


    public static class RoomEx
    {
        // Create a new Room entity from the VM
        public static Room ToModel(this RoomCreation vm)
        {
            return new Room
            {
                RoomTypeId = vm.RoomTypeId,
                Availability = vm.Availability
            };
        }

        // Update an existing Room entity from the VM
        public static void UpdateModel(this Room model, RoomCreation vm)
        {
            model.RoomTypeId = vm.RoomTypeId;
            model.Availability = vm.Availability;
        }

        // Project a Room entity into the details VM
        public static RoomDetails ToDetailsViewModel(this Room model)
        {
            return new RoomDetails
            {
                Id = model.Id,
                RoomTypeId = model.RoomTypeId,
                Availability = model.Availability.ToString(),
            };
        }
    }

}
