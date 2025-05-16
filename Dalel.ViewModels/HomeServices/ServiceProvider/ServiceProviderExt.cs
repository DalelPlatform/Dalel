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
                UserName = model.AppUser?.UserName,
                Address = model.Address,
                City = model.City,
                Price = model.Price,
                PriceUnit = model.PriceUnit,
                About = model.About,
                Website = model.Website,
                CategoryServicesId = model.CategoryServicesId,
                VerificationStatus = model.VerificationStatus,
                Schedules = model.Schedules?.Select(s => new ServiceProviderScheduleDetailsVM
                {
                    Id = s.Id,
                    WorKDay = s.WorKDay,
                    AvailableFrom = s.AvailableFrom,
                    AvailableTo = s.AvailableTo
                }).ToList(),
                Projects = model.Projects?.Select(p => new ServiceProviderProjectDetailsVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ApproximatePrice = p.ApproximatePrice,
                    PriceUnit = p.PriceUnit,
                    VideoLink = p.VideoLink,
                    ImagePaths = p.ServiceProviderProjectImages?.Select(i => i.ImagePath).ToList() ?? new List<string>()
                }).ToList()
            };
        }
    }
}
