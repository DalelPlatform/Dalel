using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Notification;

namespace Dalel.ViewModels.notification
{
    public static class Notificationexe
    {
        public static Notification ToModel(this AddNotificationVM vm)
        {
            return new Notification
            {
                UserId = vm.UserId,
                Message = vm.Message,
                IsRead = false,
                CreatedAt = DateTime.Now
            };
        }

        public static NotificationDetailsVM ToDetailsVM(this Notification model)
        {
            return new NotificationDetailsVM
            {
                Id = model.Id,
                Message = model.Message,
                IsRead = model.IsRead,
                CreatedAt = model.CreatedAt
            };
        }
    }
}
