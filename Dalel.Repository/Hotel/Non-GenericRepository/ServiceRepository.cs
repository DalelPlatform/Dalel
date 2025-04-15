using Microsoft.EntityFrameworkCore;
using Models.Hotel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dalel.Repository.Hotel.Non_GenericRepository;
using Dalel.Repository.GenericHotelRepo;
using Models;

namespace Dalel.Repository.Hotel.Non_GenericRepository
{
    public class ServiceRepository : GenericHotelRepo<Service>
    {
        private readonly DelelContext _context;
        private readonly DbSet<Service> _dbSet;

        public ServiceRepository(DelelContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Service>();
        }

        public async Task BulkInsertServicesAsync(List<Service> amenities)
        {
            var services = amenities.Select(a => new Service
            {
                Name = a.Name,
                Description = a.Description,
                IsActive = a.IsActive,
                CreatedBy = "CurrentUser",
                CreatedDate = DateTime.Now
            }).ToList();

            await _dbSet.AddRangeAsync(services);
        }

        public async Task BulkUpdateServicesAsync(List<Service> amenities)
        {
            var ids = amenities.Select(a => a.Id).ToList();
            var existingServices = await _dbSet.Where(s => ids.Contains(s.Id)).ToListAsync();

            foreach (var service in existingServices)
            {
                var update = amenities.FirstOrDefault(a => a.Id == service.Id);
                if (update != null)
                {
                    service.Name = update.Name;
                    service.Description = update.Description;
                    service.ModifiedBy = "CurrentUser";
                    service.ModifiedDate = DateTime.Now;
                    _dbSet.Update(service);
                }
            }
        }

        public async Task BulkUpdateServicesStatusAsync(List<Service> amenityStatuses)
        {
            var ids = amenityStatuses.Select(a => a.Id).ToList();
            var services = await _dbSet.Where(s => ids.Contains(s.Id)).ToListAsync();

            foreach (var service in services)
            {
                var statusUpdate = amenityStatuses.FirstOrDefault(s => s.Id == service.Id);
                if (statusUpdate != null)
                {
                    service.IsActive = statusUpdate.IsActive;
                    service.ModifiedBy = "CurrentUser";
                    service.ModifiedDate = DateTime.Now;
                }
            }

            _dbSet.UpdateRange(services);
        }
    }
}
