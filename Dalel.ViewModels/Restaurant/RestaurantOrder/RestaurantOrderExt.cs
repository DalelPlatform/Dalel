
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
                RestaurantId = order.RestaurantId,
                ClientId = order.ClientId,
                RestaurantName = order.Restaurant?.Name,
                ClientName = order.Client.User?.FirstName,

                OrderItems = order.RestaurantOrderItems?.Select(item => new RestaurantOrderItemDetailsVM
                {
                    Id = item.Id,
                    SupPrice = item.SupPrice,
                    Quantity = item.Quantity,
                    RestaurantMenuItemId = item.RestaurantMenuItemId,
                    RestaurantOrderId = item.RestaurantOrderId,
                    
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


        public static RestaurantOrder ToModel(this AddRestaurantOrderVM order)
        {
            return new RestaurantOrder
            {
                
                Date = order.Date,
                TotalPrice = order.TotalPrice,
                OrderStatus = order.OrderStatus,
                RestaurantId = order.RestaurantId,
                ClientId = order.ClientId
            };
        }


       
            public static RestaurantOrder ToEditModel(this AddRestaurantOrderVM order, RestaurantOrder oldModel)
            {
                oldModel.Date = order.Date != default
                    ? order.Date
                    : oldModel.Date;

                oldModel.TotalPrice = order.TotalPrice > 0
                    ? order.TotalPrice
                    : oldModel.TotalPrice;

                oldModel.OrderStatus = order.OrderStatus != default
                    ? order.OrderStatus
                    : oldModel.OrderStatus;

                oldModel.RestaurantId = order.RestaurantId > 0
                    ? order.RestaurantId
                    : oldModel.RestaurantId;

                oldModel.ClientId = !string.IsNullOrEmpty(order.ClientId)
                    ? order.ClientId
                    : oldModel.ClientId;

                return oldModel;
            }
        





    }
}
