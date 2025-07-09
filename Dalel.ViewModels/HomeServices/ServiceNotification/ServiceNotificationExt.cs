using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.HomeServices.ServiceNotification;
using Models;


namespace Dalel.ViewModels.HomeServices
{
    public static class ServiceNotificationExt
    {
        public static ServicesNotifications ToModel(this AddServiceNotificationVM vm)
        {
            return new ServicesNotifications
            {
                RequestId = vm.RequestId,
                ServiceProviderId = vm.ServiceProviderId,
                ClientId = vm.ClientId,
                Message = vm.Message,
                CreatedAt = vm.CreatedAt,
            };

        }
        public static ServiceNotificationDetailsVM ToDetailVM(this ServicesNotifications notification)
        {
            return new ServiceNotificationDetailsVM
            {
                Id = notification.Id,
                Message = notification.Message,
                CreatedAt = notification.CreatedAt,
            };
        }
    }
}
