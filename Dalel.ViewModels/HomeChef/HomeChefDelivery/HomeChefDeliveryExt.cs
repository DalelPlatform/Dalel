using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Models.HomeChef;

namespace Dalel.ViewModels
{
    public static class HomeChefDeliveryExt
    {
        public static HomeChefDelivery ToModel(this AddHomeChefDeliveryVM addHomeChefDeliveryVM)
        {
            return new HomeChefDelivery
            {
                PlatformLogistics = addHomeChefDeliveryVM.PlatformLogistics,
                SelfDelivery = addHomeChefDeliveryVM.SelfDelivery,
                DeliveryStatus = addHomeChefDeliveryVM.DeliveryStatus,
                HomeChefOrderId = addHomeChefDeliveryVM.HomeChefOrderId
            };
        }

        public static HomeChefDeliveryDetailsVM ToDetailsViewModel(this HomeChefDelivery homeChefDelivery)
        {
            return new HomeChefDeliveryDetailsVM
            {
                PlatformLogistics = homeChefDelivery.PlatformLogistics,
                SelfDelivery = homeChefDelivery.SelfDelivery,
                DeliveryStatus = homeChefDelivery.DeliveryStatus
            };
        }
    }
}

