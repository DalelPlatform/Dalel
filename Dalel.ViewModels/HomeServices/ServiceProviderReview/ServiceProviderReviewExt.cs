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
                RequestId = vm.RequestId,
                ServiceProviderId = vm.ServiceProviderId,
                ClientId = vm.ClientId,
                Review = vm.Review,
                Rating = vm.Rating,
                ReviewDate = vm.ReviewDate ?? DateTime.Now
            };
        }

        public static ServiceProviderReviewDetailsVM ToDetailsModel(this Models.HomeService.ServiceProviderReview model)
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
