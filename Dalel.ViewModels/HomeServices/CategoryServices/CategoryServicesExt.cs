using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.HomeService;

namespace Dalel.ViewModels.HomeServices
{
    public static class CategoryServicesExt
    {
        public static Models.HomeService.CategoryServices ToModel(this Dalel.ViewModels.HomeServices.CategoryServices.AddCategoryServicesVM vm)
        {
            return new Models.HomeService.CategoryServices
            {
                Name = vm.Name,
                Image = vm.Image,
                Description = vm.Description
            };
        }
        public static Dalel.ViewModels.HomeServices.CategoryServices.CategoryServicesDetailsVM ToDetailsModel(this Models.HomeService.CategoryServices model)
        {
            return new Dalel.ViewModels.HomeServices.CategoryServices.CategoryServicesDetailsVM
            {
                Name = model.Name,
                ImageUrl = model.Image,
                Description = model.Description,
                ServiceProvidersCount = model.ServiceProviders?.Count ?? 0,
            };
        }
    }
}
