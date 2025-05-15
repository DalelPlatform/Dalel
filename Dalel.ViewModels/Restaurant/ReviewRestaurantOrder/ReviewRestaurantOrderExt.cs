using Dalel.ViewModels.Restaurant;
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


        public static ReviewRestaurantOrder ToModel(this AddReviewRestaurantOrderVM review)
        {
            return new ReviewRestaurantOrder
            {
                Comments = review.Comments,
                Rating = review.Rating,
                ModificationDateTime = review.ModificationDateTime,
                RestaurantOrderId = review.RestaurantOrderId
            };
        }


        public static ReviewRestaurantOrder ToEditModel(this ReviewRestaurantOrderDetailsVM EditModel, ReviewRestaurantOrder oldModel)
        {
            oldModel.Comments = EditModel.Comments != null
                ? EditModel.Comments
                : oldModel.Comments;
            oldModel.Rating = EditModel.Rating > 0
                ? EditModel.Rating
                : oldModel.Rating;
            return oldModel;
        }
    }
}
