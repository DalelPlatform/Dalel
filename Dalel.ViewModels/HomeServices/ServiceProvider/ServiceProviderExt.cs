using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceProvider
{
    public static class ServiceProviderExt
    {
        public static Models.User.ServiceProvider ToModel(this AddServiceProviderVM vm)
        {
            return new Models.User.ServiceProvider
            {
                UserId = vm.UserId,
                CategoryServicesId = vm.CategoryServicesId,
                Address = vm.Address,
                City = vm.City
            };
        }

        public static Models.User.ServiceProvider ToEditModel(this AddServiceProviderVM vm, Models.User.ServiceProvider existing)
        {
            existing.UserId = vm.UserId;
            existing.CategoryServicesId = vm.CategoryServicesId;
            existing.Address = vm.Address;
            existing.City = vm.City;
            return existing;
        }

        public static ServiceProviderDetailsVM ToDetailsViewModel(this Models.User.ServiceProvider model)
        {
            var avgRating = model.Propsals
                .Where(p => p.ServiceRequest?.Review != null)
                .Average(p => (double?)p.ServiceRequest.Review.Rating) ?? 0.0;

            return new ServiceProviderDetailsVM
            {
                UserId = model.UserId,
                UserName = model.AppUser?.UserName ?? "Not Provided",
                CategoryServicesId = model.CategoryServicesId,
                CategoryName = model.CategoryServices?.Name ?? "Not Provided",
                Address = model.Address,
                City = model.City,
                AverageRating = avgRating,
                ProjectCount = model.Projects?.Count ?? 0,
                ScheduleCount = model.Schedules?.Count ?? 0,
                ProposalCount = model.Propsals?.Count ?? 0
            };
        }
    }
}
