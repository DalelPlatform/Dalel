using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Restaurant;
using Models.Enums;

namespace Dalel.ViewModels
{
    public static class RestaurantExt
    {

        public static Models.Restaurant.Restaurant ToModel(this AddRestaurantVM restaurantVM)
        {
            return new Models.Restaurant.Restaurant
            {
                OwnerId = restaurantVM.OwnerId,
                Name = restaurantVM.Name,
                Description = restaurantVM.Description,
                NumberOfRooms = restaurantVM.NumberOfRooms,
                BuildingNo = restaurantVM.BuildingNo,
                Address = restaurantVM.Address,
                City = restaurantVM.City,
                Region = restaurantVM.Region,
                Street = restaurantVM.Street,
                Latitude = restaurantVM.Latitude,
                Longitude = restaurantVM.Longitude,
                PhoneNumber = restaurantVM.PhoneNumber,
                RestaurantImages = restaurantVM.Paths.Select(i => new RestaurantImage { Image = i }).ToList() //looping 

            };
        } 


        public static RestaurantDetailsVM ToDetailsViewModel(this Models.Restaurant.Restaurant restaurant)
        {
            return new RestaurantDetailsVM
            {
                Name = restaurant.Name,
                Description = restaurant.Description,
                NumberOfRooms = restaurant.NumberOfRooms,
                BuildingNo = restaurant.BuildingNo,
                Address = restaurant.Address,
                City = restaurant.City,
                Region = restaurant.Region,
                Street = restaurant.Street,
                Latitude = restaurant.Latitude,
                Longitude = restaurant.Longitude,
                PhoneNumber = restaurant.PhoneNumber,
                Images = restaurant.RestaurantImages != null
                ? restaurant.RestaurantImages.Select(i => i.Image).ToList()
                : new List<string>()
            };
        }
        public static Models.Restaurant.Restaurant ToEditModel(this AddRestaurantVM edit, Models.Restaurant.Restaurant old)
        {
            old.Name = string.IsNullOrEmpty(edit.Name) ? old.Name : edit.Name;
            old.Description = string.IsNullOrEmpty(edit.Description) ? old.Description : edit.Description;
            old.NumberOfRooms = edit.NumberOfRooms == 0 ? old.NumberOfRooms : edit.NumberOfRooms;
            old.BuildingNo = edit.BuildingNo == 0 ? old.BuildingNo : edit.BuildingNo;
            old.Address = string.IsNullOrEmpty(edit.Address) ? old.Address : edit.Address;
            old.City = string.IsNullOrEmpty(edit.City) ? old.City : edit.City;
            old.Region = string.IsNullOrEmpty(edit.Region) ? old.Region : edit.Region;
            old.Street = string.IsNullOrEmpty(edit.Street) ? old.Street : edit.Street;
            old.Latitude = edit.Latitude == 0 ? old.Latitude : edit.Latitude;
            old.Longitude = edit.Longitude == 0 ? old.Longitude : edit.Longitude;
            old.PhoneNumber = string.IsNullOrEmpty(edit.PhoneNumber) ? old.PhoneNumber : edit.PhoneNumber;
            old.RestaurantImages = edit.Paths != null
                ? edit.Paths.Select(i => new RestaurantImage { Image = i }).ToList()
                : old.RestaurantImages;
            old.ModificationDate = DateTime.Now;

            return old;
        }

    }
}
