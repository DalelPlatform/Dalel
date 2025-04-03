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
                // Add all properties here
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
                PhoneNumber = property.PhoneNumber,
                Region = property.Region,
                Street = property.Street,
                PropertyOwner = property.PropertyOwner.AppUser.UserName ?? "Not Provided",
                Images = property.PropertyImages.Select(i => i.Image).ToList()

            };
        }
    }
}
