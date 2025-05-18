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

        public static RestaurantOrderItem ToModel(this AddRestaurantOrderItemVM restaurantOrderItem)
        {
            return new RestaurantOrderItem
            {
                
                SupPrice = restaurantOrderItem.SupPrice,
                Quantity = restaurantOrderItem.Quantity,
                RestaurantMenuItemId = restaurantOrderItem.RestaurantMenuItemId,
                RestaurantOrderId = restaurantOrderItem.RestaurantOrderId
            };
        }

        public static RestaurantOrderItem ToEditModel(this AddRestaurantOrderItemVM EditModel , RestaurantOrderItem oldModel)
        {
            oldModel.SupPrice = EditModel.SupPrice > 0
                ? EditModel.SupPrice
                : oldModel.SupPrice;

            oldModel.Quantity = EditModel.Quantity > 0
                ? EditModel.Quantity
                : oldModel.Quantity;
            oldModel.RestaurantOrderId = EditModel.RestaurantOrderId > 0
                ? EditModel.RestaurantOrderId
                : oldModel.RestaurantOrderId;
            oldModel.RestaurantMenuItemId = EditModel.RestaurantMenuItemId > 0
                ? EditModel.RestaurantMenuItemId
                : oldModel.RestaurantMenuItemId;

            return oldModel;

        }



    }
}
