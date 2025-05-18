using System.Linq;
using Models.Hotel;
using Models.Enums;  

namespace Dalel.ViewModels
{
    public static class RoomTypeEx
    {
        // Creation: map VM → EF model
        public static RoomType ToModel(this RoomTypeCreation vm)
        {
            return new RoomType
            {
                Type = vm.Type,
                MaxOccupancy = vm.MaxOccupancy,
                HasBreakfast = vm.HasBreakfast,
                Description = vm.Description,
                NumberOfRooms = vm.NumberOfRooms,
                NumberOfBeds = vm.NumberOfBeds,
                Price = vm.Price,
                HotelId = vm.HotelId,
                RoomTypeImages = vm.RoomTypeImages?
                                    .Select(img => new RoomTypeImage { Image = img })
                                    .ToList()
                                  ?? new List<RoomTypeImage>()
            };
        }

        // Update: apply VM onto existing EF model
        public static void UpdateModel(this RoomType model, RoomTypeCreation vm)
        {
            model.Type = vm.Type;
            model.MaxOccupancy = vm.MaxOccupancy;
            model.HasBreakfast = vm.HasBreakfast;
            model.Description = vm.Description;
            model.NumberOfRooms = vm.NumberOfRooms;
            model.NumberOfBeds = vm.NumberOfBeds;
            model.Price = vm.Price;
            model.HotelId = vm.HotelId;

            if (vm.RoomTypeImages != null)
            {
                model.RoomTypeImages = vm.RoomTypeImages
                    .Select(img => new RoomTypeImage { Image = img })
                    .ToList();
            }
        }

        // Details: map EF model → VM
        public static RoomTypeDetails ToDetailsViewModel(this RoomType model)
        {
            return new RoomTypeDetails
            {
                Id = model.Id,
                Type = model.Type,
                MaxOccupancy = model.MaxOccupancy,
                HasBreakfast = model.HasBreakfast,
                Description = model.Description,
                NumberOfRooms = model.NumberOfRooms,
                NumberOfBeds = model.NumberOfBeds,
                Price = model.Price,
                HotelId = model.HotelId,
                RoomTypeImages = model.RoomTypeImages?
                                     .Select(i => i.Image)
                                     .ToList()
                                   ?? new List<string>()
            };
        }
    }
}
