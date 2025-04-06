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
                RequestId = vm.Id,
                Review = vm.Review,
                Rating = vm.Rating,
                ReviewDate = DateTime.UtcNow
            };
        }

        public static ServiceProviderReviewDetailsVM ToDetailsModel(this Models.HomeService.ServiceProviderReview model)
        {
            return new ServiceProviderReviewDetailsVM
            {
                Id = model.Id,
                ClientName = model.ServiceRequest?.Client?.User.UserName ?? string.Empty,
                Review = model.Review,
                Rating = model.Rating,
                ReviewDate = model.ReviewDate.ToString("yyyy-MM-dd")
            };
        }
    }
}
