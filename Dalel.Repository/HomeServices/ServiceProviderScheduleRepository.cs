using Models.Enums;
using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class ServiceProviderScheduleRepository : BaseRepository<ServiceProviderSchedule>
    {
        public ServiceProviderScheduleRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceProviderSchedule> GetAvailableSchedules(string providerId, DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;
            return GetList(x => x.ServiceProviderId == providerId &&
                               x.WorKDay == (WorKDays)dayOfWeek);
        }
    }
}
