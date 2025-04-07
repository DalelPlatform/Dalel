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
                Name = vm.Name,
                Description = vm.Description,
                ServiceProviderProjectImages = vm.Paths.Select(path => new ServiceProviderProjectImages { ImagePath = path }).ToList()
            };
        }

        public static ServiceProviderProjectDetailsVM ToDetailsModel(this ServiceProviderProject model)
        {
            return new ServiceProviderProjectDetailsVM
            {
                Name = model.Name,
                Description = model.Description,
                Images = model.ServiceProviderProjectImages?.Select(i => i.ImagePath).ToList() ?? new List<string>(),
            };
        }
    }
}