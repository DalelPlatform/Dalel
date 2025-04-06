using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Restaurant;
using Models.Enums;

namespace Dalel.ViewModels.Restaurant.RestaurantVM
{
    public static class RestaurantExt
    {

        public static Models.Restaurant.Restaurant AddToList(this AddRestaurantVM restaurantVM)
        {
            return new Models.Restaurant.Restaurant
            {
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


        public static RestaurantDetailsVM PrintDetails (this Models.Restaurant.Restaurant restaurant)
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
    }
}
