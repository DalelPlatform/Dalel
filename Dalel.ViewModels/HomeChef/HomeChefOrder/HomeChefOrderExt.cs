using System;
using Dalel.ViewModels;
using Models.HomeChef;

namespace Dalel.ViewModels
{
    public static class HomeChefOrderExt
    {
        public static HomeChefOrder ToModel(this AddHomeChefOrderVM addHomeChefOrderVM)
        {
            return new HomeChefOrder
            {
                OrderDate = addHomeChefOrderVM.OrderDate, //Date.Now,
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

        public static HomeChefOrder ToEditModel(this AddHomeChefOrderVM addVM, HomeChefOrder old)
        {
            old.OrderDate = addVM.OrderDate != default
                ? addVM.OrderDate
                : DateTime.Now;

            old.TotalPrice = addVM.TotalPrice > 0
                ? addVM.TotalPrice
                : old.TotalPrice;

            old.OrderStatus = addVM.OrderStatus;

            old.HomeChefId = !string.IsNullOrEmpty(addVM.HomeChefId)
                ? addVM.HomeChefId
                : old.HomeChefId;

            old.ClientId = !string.IsNullOrEmpty(addVM.ClientId)
                ? addVM.ClientId
                : old.ClientId;

            return old;
        }


    }
}

