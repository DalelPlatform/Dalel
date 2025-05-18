using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.HomeServices.CategoryServices;
using Models.HomeService;

namespace Dalel.ViewModels.HomeServices
{
    public static class CategoryServicesExt
    {
        public static Models.HomeService.CategoryServices ToModel(this AddCategoryServicesVM vm)
        {
            return new Models.HomeService.CategoryServices
            {
                Name = vm.Name,
                Description = vm.Description,
                Image = vm.ImagePath
            };
        }

        public static Models.HomeService.CategoryServices ToEditModel(this AddCategoryServicesVM vm, Models.HomeService.CategoryServices existing)
        {
            existing.Name = vm.Name;
            existing.Description = vm.Description;
            existing.Image = vm.ImagePath ?? existing.Image; // Preserve existing image if no new image is provided
            return existing;
        }

        public static CategoryServicesDetailsVM ToDetailsViewModel(this Models.HomeService.CategoryServices model)
        {
            return new CategoryServicesDetailsVM
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
                ServiceProviderCount = model.ServiceProviders?.Count ?? 0,
                QueryCount = model.Quaries?.Count ?? 0
            };
        }
    }
}
