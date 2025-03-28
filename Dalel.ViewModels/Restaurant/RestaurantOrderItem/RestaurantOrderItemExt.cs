using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Restaurant;

namespace Dalel.ViewModels.Restaurant
{
    public static class RestaurantOrderItemExt
    {

        public static RestaurantOrderItemDetailsVM ToDetailsViewModel(this RestaurantOrderItem restaurantOrderItem)
        {
            return new RestaurantOrderItemDetailsVM
            {
                Id = restaurantOrderItem.Id,
                SupPrice = restaurantOrderItem.SupPrice,
                Quantity = restaurantOrderItem.Quantity,
                RestaurantMenuItemId = restaurantOrderItem.RestaurantMenuItemId,
                RestaurantOrderId  = restaurantOrderItem.RestaurantOrderId
            };
        }



    }
}
