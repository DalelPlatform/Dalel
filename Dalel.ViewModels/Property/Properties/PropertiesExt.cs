using Models.Property;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class PropertiesExt
    {
        public static Properties ToModel(this AddPropertiesVM viewModel)
        {
            return new Properties
            {
                Description = viewModel.Description,
                Amenities = viewModel.Amenities,
                PricePerNight = viewModel.PricePerNight,
                NumberOfRooms = viewModel.NumberOfRooms,
                BuildingNo = viewModel.BuildingNo,
                FloorNo = viewModel.FloorNo,
                Address = viewModel.Address,
                City = viewModel.City,
                Region = viewModel.Region,
                Street = viewModel.Street,
                Latitude = viewModel.Latitude,
                Longitude = viewModel.Longitude,
                PhoneNumber = viewModel.PhoneNumber,
                CancelationCharges = viewModel.CancelationCharges,
                CancelationOptions = viewModel.CancelationOptions,
                IsForRent = viewModel.IsForRent,
                VerificationStatus = viewModel.VerificationStatus,
                OwnerId = viewModel.OwnerId,
                PropertyImages = viewModel.Paths.Select(path => new PropertyImages
                {
                    Image = path
                }).ToList(),

            };
        }
        
        public static PropertiesDetailsVM ToDetailsViewModel(this Properties property)
        {
            return new PropertiesDetailsVM
            {
                Id = property.Id,
                Description = property.Description,
                Address = property.Address,
                Amenities = property.Amenities,
                BuildingNo = property.BuildingNo,
                City = property.City,
                FloorNo = property.FloorNo,
                IsForRent = property.IsForRent,
                NumberOfRooms = property.NumberOfRooms,
                PricePerNight = property.PricePerNight,
                PhoneNumber = property.PhoneNumber,
                Region = property.Region,
                Street = property.Street,
                Rating = property.BookingProperties.Any() ?
                    property.BookingProperties.Average(i => i.ReviewProperties == null ? 0 : i.ReviewProperties.Rating) : 0,

                PropertyOwner = property.PropertyOwner.AppUser.UserName ?? "Not Provided",
                Images = property.PropertyImages.Select(i => i.Image).ToList()

            };
        }
        public static Properties ToEditModel(this AddPropertiesVM viewModel, Properties existingProperty)
        {

            existingProperty.Description = string.IsNullOrEmpty(viewModel.Description) ? existingProperty.Description : viewModel.Description;
            existingProperty.Amenities = string.IsNullOrEmpty(viewModel.Amenities) ? existingProperty.Amenities : viewModel.Amenities;
            existingProperty.PricePerNight = viewModel.PricePerNight == 0 ? existingProperty.PricePerNight : viewModel.PricePerNight;
            existingProperty.NumberOfRooms = viewModel.NumberOfRooms == 0 ? existingProperty.NumberOfRooms : viewModel.NumberOfRooms;
            existingProperty.BuildingNo = viewModel.BuildingNo == 0 ? existingProperty.BuildingNo : viewModel.BuildingNo;
            existingProperty.FloorNo = viewModel.FloorNo == 0 ? existingProperty.FloorNo : viewModel.FloorNo;
            existingProperty.Address = string.IsNullOrEmpty(viewModel.Address) ? existingProperty.Address : viewModel.Address;
            existingProperty.City = string.IsNullOrEmpty(viewModel.City) ? existingProperty.City : viewModel.City;
            existingProperty.Region = string.IsNullOrEmpty(viewModel.Region) ? existingProperty.Region : viewModel.Region;
            existingProperty.Street = string.IsNullOrEmpty(viewModel.Street) ? existingProperty.Street : viewModel.Street;
            existingProperty.Latitude = viewModel.Latitude == 0 ? existingProperty.Latitude : viewModel.Latitude;
            existingProperty.Longitude = viewModel.Longitude == 0 ? existingProperty.Longitude : viewModel.Longitude;
            existingProperty.PhoneNumber = string.IsNullOrEmpty(viewModel.PhoneNumber) ? existingProperty.PhoneNumber : viewModel.PhoneNumber;
            existingProperty.CancelationCharges = viewModel.CancelationCharges == 0 ? existingProperty.CancelationCharges : viewModel.CancelationCharges;
            existingProperty.CancelationOptions = viewModel.CancelationOptions == false ? existingProperty.CancelationOptions : viewModel.CancelationOptions;
            existingProperty.IsForRent = viewModel.IsForRent == false ? existingProperty.IsForRent : viewModel.IsForRent;
            existingProperty.ModificationDate = DateTime.Now;
            existingProperty.IsDeleted = false;
            existingProperty.PropertyImages = viewModel.Paths.Select(path => new PropertyImages
            {
                Image = path
            }).ToList();
            existingProperty.VerificationStatus = viewModel.VerificationStatus == 0 ? existingProperty.VerificationStatus : viewModel.VerificationStatus;


            // Ensure the OwnerId is not changed
            if (!string.IsNullOrEmpty(viewModel.OwnerId) && viewModel.OwnerId != existingProperty.OwnerId)
            {
                throw new InvalidOperationException("OwnerId cannot be changed.");
            }
            existingProperty.OwnerId = existingProperty.OwnerId; // Keep the existing OwnerId
           
            return existingProperty;
        }
    }
}
