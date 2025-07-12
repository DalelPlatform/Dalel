using Models.HomeService;
using Models.Restaurant;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Dalel.ViewModels
{
    public static class ServiceProviderProjectExt
    {
        public static ServiceProviderProject ToModel(this AddServiceProviderProjectVM vm)
        {
            var project = new ServiceProviderProject
            {
                Name = vm.Name,
                Description = vm.Description,
                ApproximatePrice = vm.ApproximatePrice,
                PriceUnit = vm.PriceUnit,
                ServiceProviderId = vm.ServiceProviderId,
                Image =  vm.Image != null ? $"/images/serviceproviderProject/{vm.ServiceProviderId}/{vm.Image.FileName}" : null,

            };

            return project;
        }

        public static ServiceProviderProject ToEditModel(this AddServiceProviderProjectVM vm, ServiceProviderProject existing)
        {
            existing.Name = vm.Name;
            existing.Description = vm.Description;
            existing.ApproximatePrice = vm.ApproximatePrice;
            existing.PriceUnit = vm.PriceUnit;
            existing.Image = vm.Image != null ? vm.Imagepath : existing.Image;

            return existing;
        }

        public static ServiceProviderProjectDetailsVM ToDetailsViewModel(this ServiceProviderProject model)
        {
            return new ServiceProviderProjectDetailsVM
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ApproximatePrice = model.ApproximatePrice,
                PriceUnit = model.PriceUnit,
                Image = model.Image,

            };
        }
    }
}