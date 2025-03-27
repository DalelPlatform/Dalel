using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Restaurant;

namespace Dalel.ViewModels
{
    public static class RestaurantMenuItemExt
    {
        


        //public static RestaurantMenuItem ToModel(this AddRestaurantMenuItemVM menuItemVM )
        //{

        //    return new RestaurantMenuItem
        //    {
        //        Id = menuItemVM.
        //    }
        //}


        public static RestaurantMenuItemDetailsVM ToDetailsViewModel (this RestaurantMenuItem menuItem)
        {
            return new RestaurantMenuItemDetailsVM
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                AvailabilityStatus = menuItem.AvailabilityStatus,
                DietaryTags = menuItem.DietaryTags,
                FoodCategory = menuItem.FoodCategory,
                Price = menuItem.Price,
                PieceSize = menuItem.PieceSize,
                //VendorName = viewModel.Vendor.User.UserName ?? "Not Provided",
                RestaurantName = menuItem.Restaurant.RestaurantOwner.AppUser.UserName ?? "Not Provided",
                Images = menuItem.RestaurantMenuItemImages.Select(i => i.Image).ToList()

            };
        }
    }
}
