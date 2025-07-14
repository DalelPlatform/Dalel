
using Dalel.ViewModels;
using Dalel.ViewModels.Restaurant;
using Models.Restaurant;
using System.Linq;

namespace Dalel.Extensions
{
    public static class RestaurantOrderExt
    {
        public static RestaurantOrderDetailsVM ToDetailsViewModel(this RestaurantOrder order)
        {
            return new RestaurantOrderDetailsVM
            {
                Id = order.Id,
                Date = order.Date,
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus,
                ClientId = order.ClientId,
                ClientName = order.Client.User?.FirstName,

                OrderItems = order.RestaurantOrderItems?.Select(item => new RestaurantOrderItemDetailsVM
                {
                    Id = item.Id,
                    SupPrice = item.SupPrice,
                    Quantity = item.Quantity,
                    RestaurantMenuItemId = item.RestaurantMenuItemId,
                    RestaurantOrderId = item.RestaurantOrderId,
                    RestaurantId = item.RestaurantMenuItem.RestaurantId,
                    RestaurantName = item.RestaurantMenuItem.Restaurant.Name
                    
                }).ToList(),

                Review = order.ReviewRestaurantOrder != null
                    ? new ReviewRestaurantOrderDetailsVM
                    {
                        
                        Comments = order.ReviewRestaurantOrder.Comments,
                        Rating = order.ReviewRestaurantOrder.Rating,
                        RestaurantOrderId = order.ReviewRestaurantOrder.RestaurantOrderId
                    }
                    : null,

                Payment = order.PaymentRestaurantOrder != null
                    ? order.PaymentRestaurantOrder.ToDetailsViewModel()
                    : null
            };
        }


        public static RestaurantOrder ToModel(this AddRestaurantOrderVM order, List<RestauranCartItemDetailsVM> cart)
        {
            return new RestaurantOrder
            {

                Date = order.Date,
                Address=order.Address,
                City=order.City,
                Note=order.Note,
                PhoneNumber=order.PhoneNumber,
                OrderStatus = order.OrderStatus,
                ClientId = order.ClientId,
                RestaurantOrderItems = cart.Select(item => new RestaurantOrderItem
                {
                    SupPrice = item.SupPrice,
                    Quantity = item.Quantity,
                    RestaurantMenuItemId = item.RestaurantMenuItemId,
                    
                }).ToList(),

                TotalPrice = cart.Sum(item => item.SupPrice)
            };
        }


       
            public static RestaurantOrder ToEditModel(this AddRestaurantOrderVM order, RestaurantOrder oldModel)
            {
                oldModel.Date = order.Date != default
                    ? order.Date
                    : oldModel.Date;

                //oldModel.TotalPrice = order.TotalPrice > 0
                //    ? order.TotalPrice
                //    : oldModel.TotalPrice;

                oldModel.OrderStatus = order.OrderStatus != default
                    ? order.OrderStatus
                    : oldModel.OrderStatus;


                oldModel.ClientId = !string.IsNullOrEmpty(order.ClientId)
                    ? order.ClientId
                    : oldModel.ClientId;

                return oldModel;
            }
        





    }
}
