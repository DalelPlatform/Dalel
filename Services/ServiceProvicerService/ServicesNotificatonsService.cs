using Microsoft.AspNetCore.SignalR;
using Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Dalel.Services
{


    public interface INotificationService
    {
        Task SendNotificationAsync(string toUserId, string message, int requestId, string fromUserId, bool isToClient);
    }

    public class NotificationService : INotificationService
    {
        private readonly DelelContext _context;
        private readonly IHubContext<NotificationServiceHub> _hubContext;

        public NotificationService(DelelContext context, IHubContext<NotificationServiceHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(string toUserId, string message, int requestId, string fromUserId, bool isToClient)
        {
            var notification = new ServicesNotifications
            {
                Message = message,
                CreatedAt = DateTime.Now,
                RequestId = requestId,
                ClientId = isToClient ? toUserId : fromUserId,
                ServiceProviderId = isToClient ? fromUserId : toUserId
            };

            _context.ServicesNotifications.Add(notification);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.User(toUserId).SendAsync("ReceiveNotification", new
            {
                message = message,
                requestId = requestId,
                createdAt = notification.CreatedAt.ToString("g")
            });
        }
    }

}
