using System;
using Dalel.ViewModels.HomeChef.HomeChefOrderMeal;
using Models.HomeChef;

namespace Dalel.ViewModels
{
    public static class HomeChefOrderExt
    {
        public static HomeChefOrder ToModel(this AddHomeChefOrderVM addHomeChefOrderVM)
        {
            return new HomeChefOrder
            {
                OrderDate = addHomeChefOrderVM.OrderDate,
                TotalPrice = addHomeChefOrderVM.TotalPrice,
                OrderStatus = addHomeChefOrderVM.OrderStatus,
                HomeChefId = addHomeChefOrderVM.HomeChefId,
                ClientId = addHomeChefOrderVM.ClientId
            };
        }

        public static HomeChefOrderDetailsVM ToDetailsViewModel(this HomeChefOrder homeChefOrder)
        {
            return new HomeChefOrderDetailsVM
            {
                OrderDate = homeChefOrder.OrderDate,
                TotalPrice = homeChefOrder.TotalPrice,
                OrderStatus = homeChefOrder.OrderStatus
            };
        }
    }
}

