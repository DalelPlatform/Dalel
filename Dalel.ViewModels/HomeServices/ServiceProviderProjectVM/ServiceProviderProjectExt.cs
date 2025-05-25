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
            var project = new ServiceProviderProject
            {
                Name = vm.Name,
                Description = vm.Description,
                ApproximatePrice = vm.ApproximatePrice,
                PriceUnit = vm.PriceUnit,
                VideoLink = vm.VideoLink,
                ServiceProviderId = vm.ServiceProviderId 
            };
            project.ServiceProviderProjectImages = new List<ServiceProviderProjectImages>();

            if(vm.ImageFiles != null && vm.ImageFiles.Any())
            {
                foreach (var imageFile in vm.ImageFiles)
                {
                    project.ServiceProviderProjectImages.Add(new ServiceProviderProjectImages
                    {
                        ImagePath = imageFile.Value 
                    });
                }
            }

            return project;
        }

        public static ServiceProviderProject ToEditModel(this AddServiceProviderProjectVM vm, ServiceProviderProject existing)
        {
            existing.Name = vm.Name;
            existing.Description = vm.Description;
            existing.ApproximatePrice = vm.ApproximatePrice;
            existing.PriceUnit = vm.PriceUnit;
            existing.VideoLink = vm.VideoLink;

            if(vm.ImageFiles != null && vm.ImageFiles.Any())
            {
                // Clear existing images and add the new ones
                existing.ServiceProviderProjectImages.Clear();
                foreach (var imageFile in vm.ImageFiles)
                {
                    existing.ServiceProviderProjectImages.Add(new ServiceProviderProjectImages
                    {
                        ImagePath = imageFile.Value
                    });
                }
            }


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
                VideoLink = model.VideoLink,
                ImagePaths = model.ServiceProviderProjectImages?.Select(i => i.ImagePath).ToList() ?? new List<string>()
            };
        }
    }
}