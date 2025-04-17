using Models.Hotel;

namespace Dalel.ViewModels
{
    public static class RoomEx
    {
        public static RoomDetails ToDetailsViewModel(this Room room)
        {
            if (room == null) return null;

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
