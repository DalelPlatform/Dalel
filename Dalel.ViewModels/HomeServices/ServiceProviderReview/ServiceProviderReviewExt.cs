using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ServiceProviderReviewExt
    {
        public static Models.HomeService.ServiceProviderReview ToModel(this AddServiceProviderReviewVM vm)
        {
            return new Models.HomeService.ServiceProviderReview
            {
                Id = vm.Id,
                Review = vm.Review,
                Rating = vm.Rating,
                ServiceProviderId = vm.ServiceProviderId,
                ClientId = vm.ClientId,
                RequestId = vm.RequestId,
                ReviewDate = DateTime.Now 
            };


        }

        public static ServiceProviderReviewDetailsVM ToDetailsModel(this ServiceProviderReview model)
        {
            return new ServiceProviderReviewDetailsVM
            {
                Id = model.Id,
                Review = model.Review,
                Rating = model.Rating,
                ServiceProviderId = model.ServiceProviderId,
                ClientId = model.ClientId,
                RequestId = model.RequestId,
                ReviewDate = model.ReviewDate
            };
        }
    }
}
