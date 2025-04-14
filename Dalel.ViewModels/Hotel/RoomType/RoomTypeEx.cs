using Models.Hotel;

namespace Dalel.ViewModels
{
    public static class RoomTypeEx
    {
        public static RoomTypeDetails ToDetailsViewModel(this RoomType roomType)
        {
            return new RoomTypeDetails
            {
                Id = roomType.Id,
                Type = roomType.Type.ToString(),
                MaxOccupancy = roomType.MaxOccupancy,
                HasBreakfast = roomType.HasBreakfast,
                Description = roomType.Description,
                NumberOfRooms = roomType.NumberOfRooms,
                NumberOfBeds = roomType.NumberOfBeds,
                Price = roomType.Price,
                HotelId = roomType.HotelId,
                RoomTypeImages = roomType.RoomTypeImages?.Select(i => i.Image).ToList() ?? new List<string>()
            };
        }
    }
}
