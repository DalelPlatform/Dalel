using Dalel.ViewModels.HomeServices;
using Dalel.ViewModels.HomeServices.ServiceNotification;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository.HomeServices
{

    public class ServiceNotificationRepository
    {
        private readonly DelelContext _context;

        public ServiceNotificationRepository(DelelContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AddServiceNotificationVM notification)
        {
            _context.ServicesNotifications.Add(notification.ToModel());
            await _context.SaveChangesAsync();
        }
        public async Task AddClass(ServicesNotifications notification)
        {
            _context.ServicesNotifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ServicesNotifications>> GetUserNotificationsAsync(string userId)
        {
            return await _context.ServicesNotifications
                .Where(n => n.ClientId == userId || n.ServiceProviderId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

    }
}
