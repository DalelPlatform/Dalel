using Models.Enums;
using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dalel.Repository
{
    public class ServiceProviderScheduleRepository : BaseRepository<ServiceProviderSchedule>
    {
        private readonly DelelContext _context;

        public ServiceProviderScheduleRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceProviderSchedule>> GetSchedulesByProviderAsync(string providerId)
        {
            return await _context.ServiceProviderSchedules
                .Where(s => s.ServiceProviderId == providerId)
                .OrderBy(s => s.WorKDay)
                .ThenBy(s => s.AvailableFrom)
                .ToListAsync();
        }

        public async Task<bool> IsProviderAvailableAsync(string providerId, DateTime date, TimeOnly time)
        {
            var day = (WorKDays)date.DayOfWeek;
            return await _context.ServiceProviderSchedules
                .AnyAsync(s => s.ServiceProviderId == providerId &&
                              s.WorKDay == day &&
                              s.AvailableFrom <= time &&
                              s.AvailableTo >= time);
        }

        public async Task UpdateProviderScheduleAsync(string providerId, IEnumerable<ServiceProviderSchedule> schedules)
        {
            var existingSchedules = await _context.ServiceProviderSchedules
                .Where(s => s.ServiceProviderId == providerId)
                .ToListAsync();

            _context.ServiceProviderSchedules.RemoveRange(existingSchedules);
            await _context.ServiceProviderSchedules.AddRangeAsync(schedules);
        }

        public async Task<PagedResult<ServiceProviderSchedule>> FilterSchedulesAsync(
            string providerId = null,
            WorKDays? day = null,
            TimeOnly? availableFrom = null,
            TimeOnly? availableTo = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "WorKDay",
            bool ascending = true)
        {
            var query = _context.ServiceProviderSchedules
                .Include(s => s.ServiceProvider)
                .AsQueryable();

            if (!string.IsNullOrEmpty(providerId))
            {
                query = query.Where(s => s.ServiceProviderId == providerId);
            }

            if (day.HasValue)
            {
                query = query.Where(s => s.WorKDay == day.Value);
            }

            if (availableFrom.HasValue)
            {
                query = query.Where(s => s.AvailableFrom >= availableFrom.Value);
            }

            if (availableTo.HasValue)
            {
                query = query.Where(s => s.AvailableTo <= availableTo.Value);
            }

            // Sorting
            query = sortBy switch
            {
                "WorKDay" => ascending
                    ? query.OrderBy(s => s.WorKDay).ThenBy(s => s.AvailableFrom)
                    : query.OrderByDescending(s => s.WorKDay).ThenByDescending(s => s.AvailableFrom),
                "AvailableFrom" => ascending
                    ? query.OrderBy(s => s.AvailableFrom)
                    : query.OrderByDescending(s => s.AvailableFrom),
                "AvailableTo" => ascending
                    ? query.OrderBy(s => s.AvailableTo)
                    : query.OrderByDescending(s => s.AvailableTo),
                _ => query.OrderBy(s => s.WorKDay).ThenBy(s => s.AvailableFrom)
            };

            var result = new PagedResult<ServiceProviderSchedule>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = await query.CountAsync()
            };

            result.Items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }
    }
}
