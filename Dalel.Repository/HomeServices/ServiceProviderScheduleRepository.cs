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
        }

        public bool DeleteSchedule(string providerId, DateTime date)
        {
            var day = (WorKDays)date.DayOfWeek;
            var schedulesToDelete = base.GetList(s => s.ServiceProviderId == providerId && s.WorKDay == day).ToList();

            if (!schedulesToDelete.Any())
                return false;

            _context.ServiceProviderSchedules.RemoveRange(schedulesToDelete);
            _context.SaveChanges();
            return true;
        }

        public IQueryable<ServiceProviderSchedule> GetSchedulesByProvider(string providerId)
        {
            return (IQueryable<ServiceProviderSchedule>)base.GetList(s=> s.ServiceProviderId == providerId).OrderBy(s => s.WorKDay).ThenBy(s => s.AvailableFrom).ToList();
        }

        public bool IsProviderAvailable(string providerId, DateTime date, TimeOnly time)
        {
            var day = (WorKDays)date.DayOfWeek;
            var schedules = base.GetList(s =>
                s.ServiceProviderId == providerId &&
                s.WorKDay == day)
                .OrderBy(s => s.WorKDay)
                .ThenBy(s => s.AvailableFrom)
                .ToList();

            return schedules.Any(s =>
                s.AvailableFrom <= time &&
                s.AvailableTo >= time);
        }

        public void UpdateProviderSchedule(string providerId, IQueryable<ServiceProviderSchedule> schedules)
        {
            var existingSchedules = base.GetList(s => s.ServiceProviderId == providerId);
            foreach (var schedule in existingSchedules)
            {
                base.Delete(schedule);
            }
            foreach (var schedule in schedules)
            {
                base.Add(schedule);
            }
            base.Save();
        }

        //public async Task<PagedResult<ServiceProviderSchedule>> FilterSchedulesAsync(
        //    string providerId = null,
        //    WorKDays? day = null,
        //    TimeOnly? availableFrom = null,
        //    TimeOnly? availableTo = null,
        //    int pageNumber = 1,
        //    int pageSize = 10,
        //    string sortBy = "WorKDay",
        //    bool ascending = true)
        //{
        //    var query = _context.ServiceProviderSchedules
        //        .Include(s => s.ServiceProvider)
        //        .AsQueryable();

        //    if (!string.IsNullOrEmpty(providerId))
        //    {
        //        query = query.Where(s => s.ServiceProviderId == providerId);
        //    }

        //    if (day.HasValue)
        //    {
        //        query = query.Where(s => s.WorKDay == day.Value);
        //    }

        //    if (availableFrom.HasValue)
        //    {
        //        query = query.Where(s => s.AvailableFrom >= availableFrom.Value);
        //    }

        //    if (availableTo.HasValue)
        //    {
        //        query = query.Where(s => s.AvailableTo <= availableTo.Value);
        //    }

        //    // Sorting
        //    query = sortBy switch
        //    {
        //        "WorKDay" => ascending
        //            ? query.OrderBy(s => s.WorKDay).ThenBy(s => s.AvailableFrom)
        //            : query.OrderByDescending(s => s.WorKDay).ThenByDescending(s => s.AvailableFrom),
        //        "AvailableFrom" => ascending
        //            ? query.OrderBy(s => s.AvailableFrom)
        //            : query.OrderByDescending(s => s.AvailableFrom),
        //        "AvailableTo" => ascending
        //            ? query.OrderBy(s => s.AvailableTo)
        //            : query.OrderByDescending(s => s.AvailableTo),
        //        _ => query.OrderBy(s => s.WorKDay).ThenBy(s => s.AvailableFrom)
        //    };

        //    var result = new PagedResult<ServiceProviderSchedule>
        //    {
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        TotalCount = await query.CountAsync()
        //    };

        //    result.Items = await query
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return result;
        //}
    }
}
