using Dalel.ViewModels.HomeServices.ServiceProviderSchedule;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ServiceProviderScheduleExt
    {
        public static ServiceProviderSchedule ToModel(this AddServiceProviderScheduleItemVM vm ,string ServiceProviderId)
        {
            return new ServiceProviderSchedule
            {
                WorKDay = vm.WorKDay,
                AvailableFrom = vm.AvailableFrom,
                AvailableTo = vm.AvailableTo,
                ServiceProviderId = ServiceProviderId
            };
        }

        public static ServiceProviderScheduleDetailsVM ToDetailsViewModel(this ServiceProviderSchedule model)
        {
            return new ServiceProviderScheduleDetailsVM
            {
                Id = model.Id,
                ServiceProviderId = model.ServiceProviderId,
                ServiceProviderName = model.ServiceProvider?.AppUser?.UserName ?? "Not Provided",
                WorKDay = model.WorKDay,
                AvailableFrom = model.AvailableFrom,
                AvailableTo = model.AvailableTo
            };
        }
    }
}
