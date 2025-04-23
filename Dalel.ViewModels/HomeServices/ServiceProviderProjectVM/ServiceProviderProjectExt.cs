using Models.HomeService;
using Models.Restaurant;
using System.Collections.Generic;
using System.Linq;

namespace Dalel.ViewModels
{
    public static class ServiceProviderProjectExt
    {
        public static ServiceProviderProject ToModel(this AddServiceProviderProjectVM vm)
        {
            return new ServiceProviderProject
            {
                ServiceProviderId = vm.ServiceProviderId,
                Name = vm.Name,
                Description = vm.Description,
                ProjectImages = vm.ImagePath
            };
        }
        public static ServiceProviderProject ToEditModel(this AddServiceProviderProjectVM vm, ServiceProviderProject existing)
        {
            existing.ServiceProviderId = vm.ServiceProviderId;
            existing.Name = vm.Name;
            existing.Description = vm.Description;
            existing.ProjectImages = vm.ImagePath ?? existing.ProjectImages;
            return existing;
        }

        public static ServiceProviderProjectDetailsVM ToDetailsViewModel(this ServiceProviderProject model)
        {
            return new ServiceProviderProjectDetailsVM
            {
                Id = model.Id,
                ServiceProviderId = model.ServiceProviderId,
                ServiceProviderName = model.ServiceProvider?.AppUser?.UserName ?? "Not Provided",
                Name = model.Name,
                Description = model.Description,
                ProjectImages = model.ProjectImages
            };
        }
    }
}