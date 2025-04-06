using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceProviderSchedule
{
    public static class ServiceProviderScheduleExt
    {
        public static Models.HomeService.ServiceProviderSchedule ToModel(this AddServiceProviderScheduleVM vm)
        {
            return new Models.HomeService.ServiceProviderSchedule
            {
                WorKDay = vm.WorkDay,
                AvailableFrom = vm.AvailableFrom,
                AvailableTo = vm.AvailableTo,
            };
        }

        public static ServiceProviderScheduleDetailsVM ToDetailsModel(this Models.HomeService.ServiceProviderSchedule model)
        {
            return new ServiceProviderScheduleDetailsVM
            {
                Id = model.Id,
                Day = model.WorKDay.ToString(),
                AvailableFrom = model.AvailableFrom.ToString("hh\\:mm"),
                AvailableTo = model.AvailableTo.ToString("hh\\:mm"),
                ProviderName = model.ServiceProvider?.AppUser.UserName ?? string.Empty
            };
        }
    }
}
