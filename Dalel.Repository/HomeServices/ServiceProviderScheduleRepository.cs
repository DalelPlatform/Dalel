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
        public void AddSchedule(ServiceProviderSchedule schedule)
        {
            var existingSchedules = base.GetList(s => s.ServiceProviderId == schedule.ServiceProviderId && s.WorKDay == schedule.WorKDay).ToList();
            if (existingSchedules.Any())
            {
                foreach (var existingSchedule in existingSchedules)
                {
                    base.Delete(existingSchedule);
                }
            }
            base.Add(schedule);
            base.Save();
        }
        public void AddSchedule(IQueryable<ServiceProviderSchedule> schedules)
        {
            foreach (var item in schedules)
            {
                base.Add(item);
                base.Save();
                
            }

        }

        public bool DeleteSchedule(string providerId, DateTime date)
        {
            var day = (WorKDays)date.DayOfWeek;
            var schedulesToDelete = base.GetList(s => s.ServiceProviderId == providerId && s.WorKDay == day).ToList();

            if (!schedulesToDelete.Any())
                return false;

            _context.ServiceProviderSchedules.RemoveRange(schedulesToDelete);
            base.Save();
            return true;
        }

        public IQueryable<ServiceProviderSchedule> GetSchedulesByProvider(string providerId)
        {
            return base.GetList(s => s.ServiceProviderId == providerId)
                       .OrderBy(s => s.WorKDay)
                       .ThenBy(s => s.AvailableFrom)
                       .AsQueryable();
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
    }
}
