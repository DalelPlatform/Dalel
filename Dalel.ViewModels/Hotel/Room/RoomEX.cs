using System;
using System.Collections.Generic;
using Models.Hotel;

namespace Dalel.ViewModels
{
    public static class RoomEx
    {
        public static RoomDetails ToDetailsViewModel(this Room room)
        {
            return new RoomDetails
            {
                Id = room.Id,
                Availability = room.Availability.ToString(),
                RoomTypeId = room.RoomTypeId,
                RoomTypeName = room.RoomType?.Type.ToString(),
                RoomTypePrice = room.RoomType?.Price ?? 0
            };
        }
    }
}
