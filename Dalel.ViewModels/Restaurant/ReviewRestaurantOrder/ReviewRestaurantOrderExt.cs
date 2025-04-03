using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ReviewRestaurantOrderExt
    {
        public static ReviewRestaurantOrderDetailsVM ToDetailsViewModel(this ReviewRestaurantOrder review)
        {
            return new ReviewRestaurantOrderDetailsVM
            {
                Comments = review.Comments,
                Rating = review.Rating,
                RestaurantOrderId = review.RestaurantOrderId
            };
        }
    }
}
