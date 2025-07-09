using Dalel.Repository.HomeServices;
using Dalel.ViewModels.HomeServices.ServiceNotification;
using Dalel.ViewModels.notification;
using Microsoft.AspNetCore.SignalR;
using Models;
using Models.Migrations;
using Models.Notification;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Services
{
    public class NotificationService 
    {
        private readonly ServiceNotificationRepository _repo;
        private readonly IHubContext<NotificationServiceHub> _hub;

        public NotificationService(ServiceNotificationRepository repo, IHubContext<NotificationServiceHub> hub)
        {
            _repo = repo;
            _hub = hub;
        }

        public async Task SendNotificationAsync(AddNotificationVM model)
        {
            var notification = new ServicesNotifications
            {
                Message = model.Message,
                CreatedAt = DateTime.Now,
                RequestId = model.RequestId,
                ClientId = model.IsToClient ? model.ToUserId : model.FromUserId,
                ServiceProviderId = model.IsToClient ? model.FromUserId : model.ToUserId
            };

            await _repo.AddAsync(notification);

            await _hub.Clients.User(model.ToUserId).SendAsync("ReceiveNotification", new
            {
                message = model.Message,
                requestId = model.RequestId,
                createdAt = notification.CreatedAt.ToString("g")
            });
        }

        public async Task<List<ServiceNotificationDetailsVM>> GetNotificationsAsync(string userId)
        {
            var list = await _repo.GetUserNotificationsAsync(userId);
            return list.Select(n => new ServiceNotificationDetailsVM
            {
                Id = n.Id,
                Message = n.Message,
                CreatedAt = n.CreatedAt,
                UserType = n.ClientId == userId ? "ServiceProvider" : "Client"
            }).ToList();
        }
    }


}
