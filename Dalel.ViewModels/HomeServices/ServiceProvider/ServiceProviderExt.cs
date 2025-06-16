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
                City = vm.City,
                Country = vm.Country,
                District = vm.District,
                Price = vm.Price,
                PriceUnit = vm.PriceUnit,
                About = vm.About,
                Website = vm.Website,
                ServiceArea = vm.ServiceArea,
                ZipCode = vm.ZipCode,
                Image = vm.Image != null ? $"/images/serviceprovider/{vm.UserId}/{vm.Image.FileName}" : null,

                Schedules = vm.Schedules?.Select(s => new Models.HomeService.ServiceProviderSchedule
                {
                    WorKDay = s.WorKDay,
                    AvailableFrom = s.AvailableFrom,
                    AvailableTo = s.AvailableTo
                }).ToList() ?? new List<Models.HomeService.ServiceProviderSchedule>()
            };
        }

        public static Models.User.ServiceProvider ToEditModel(this AddServiceProviderVM vm, Models.User.ServiceProvider existing)
        {
            existing.UserId = vm.UserId;
            existing.CategoryServicesId = vm.CategoryServicesId;
            existing.Address = vm.Address;
            existing.City = vm.City;
            existing.Price = vm.Price;
            existing.PriceUnit = vm.PriceUnit;
            existing.About = vm.About;
            existing.Website = vm.Website;
            existing.ServiceArea = vm.ServiceArea;
            existing.ZipCode = vm.ZipCode;
            existing.Image = vm.Image != null ? vm.Imagepath : existing.Image;
            existing.Country = vm.Country;
            if (vm.Schedules != null)
            {
                existing.Schedules = vm.Schedules.Select(s => new Models.HomeService.ServiceProviderSchedule
                {
                    WorKDay = s.WorKDay,
                    AvailableFrom = s.AvailableFrom,
                    AvailableTo = s.AvailableTo
                }).ToList();
            }
            else if (existing.Schedules == null)
            {
                existing.Schedules = new List<Models.HomeService.ServiceProviderSchedule>();
            }

            return existing;
        }

        public static ServiceProviderDetailsVM ToDetailsViewModel(this Models.User.ServiceProvider model)
        {
            var avgRating = model.Propsals
               ?.Where(p => p.ServiceRequest?.Review != null)
               .Average(p => (double?)p.ServiceRequest.Review.Rating) ?? 0.0;

            return new ServiceProviderDetailsVM
            {
                UserId = model.UserId,
                UserName = model.AppUser?.UserName ?? "Not Provided",
                Address = model.Address ?? "",
                City = model.City ?? "",
                Price = model.Price,
                PriceUnit = model.PriceUnit,
                About = model.About,
                Website = model.Website,
                CategoryServicesId = model.CategoryServicesId,
                Country = model.Country ?? "",
                ServiceArea = model.ServiceArea ?? "",
                ZipCode = model.ZipCode ?? "",
                District = model.District ?? "",
                Image = model.Image,
                Schedules = model.Schedules?.Select(s => new ServiceProviderScheduleDetailsVM
                {
                    Id = s.Id,
                    WorKDay = s.WorKDay,
                    AvailableFrom = s.AvailableFrom,
                    AvailableTo = s.AvailableTo
                }).ToList() ?? new List<ServiceProviderScheduleDetailsVM>(),
                Projects = model.Projects?.Select(p => new ServiceProviderProjectDetailsVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ApproximatePrice = p.ApproximatePrice,
                    PriceUnit = p.PriceUnit,
                    VideoLink = p.VideoLink,
                    ImagePaths = p.ServiceProviderProjectImages?.Select(i => i.ImagePath).ToList() ?? new List<string>()
                }).ToList() ?? new List<ServiceProviderProjectDetailsVM>()
            };
        }
    }
}
