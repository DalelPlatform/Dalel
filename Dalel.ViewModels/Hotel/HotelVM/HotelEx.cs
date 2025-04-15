using System.Linq;
using Models.Hotel;
using Models.Enums; // Ensure this namespace contains your VerificationStatus enum

namespace Dalel.ViewModels
{
    public static class HotelEx
    {
        public static Models.Hotel.Hotel ToModel(this HotelCreation hotelVM)
        {
            return new Models.Hotel.Hotel
            {
                Name = hotelVM.Name,
                Description = hotelVM.Description,
                City = hotelVM.City,
                Street = hotelVM.Street,
                Address = hotelVM.Address,
                Latitude = hotelVM.Latitude,
                Longitude = hotelVM.Longitude,
                PhoneNumber = hotelVM.PhoneNumber,
                CancelationOptions = hotelVM.CancelationOptions,
                CancelationCharges = hotelVM.CancelationCharges,
                OwnerId = hotelVM.OwnerId,
                IsDeleted = false,
                VerificationStatus = VerificationStatus.Pending, // Assumes a default pending status
                // Map images from provided paths
                HotelImages = hotelVM.Paths.Select(p => new HotelImage { Image = p }).ToList()
            };
        }

        public static HotelDetails ToDetailsViewModel(this Models.Hotel.Hotel hotel)
        {
            return new HotelDetails
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Description = hotel.Description,
                City = hotel.City,
                Street = hotel.Street,
                Address = hotel.Address,
                Latitude = hotel.Latitude,
                Longitude = hotel.Longitude,
                PhoneNumber = hotel.PhoneNumber,
                CancelationOptions = hotel.CancelationOptions,
                CancelationCharges = hotel.CancelationCharges,
                OwnerId = hotel.OwnerId,
                VerificationStatus = hotel.VerificationStatus.ToString(),
                Images = hotel.HotelImages != null
                    ? hotel.HotelImages.Select(i => i.Image).ToList()
                    : new System.Collections.Generic.List<string>()
            };
        }
    }
}
