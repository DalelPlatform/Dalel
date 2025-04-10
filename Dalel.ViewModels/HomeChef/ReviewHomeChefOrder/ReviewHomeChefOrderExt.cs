using Dalel.ViewModels.HomeChef.ReviewHomeChefOrder;
using Models.HomeChef;

namespace Dalel.ViewModels
{
    public static class ReviewHomeChefOrderExt
    {
        public static ReviewHomeChefOrder ToModel(this AddReviewHomeChefOrderVM addReviewHomeChefOrderVM)
        {
            return new ReviewHomeChefOrder
            {
                Comments = addReviewHomeChefOrderVM.Comments,
                Rating = addReviewHomeChefOrderVM.Rating,
                ModificationDateTime = addReviewHomeChefOrderVM.ModificationDateTime,
                HomeChefOrderId = addReviewHomeChefOrderVM.HomeChefOrderId ?? 0 // If HomeChefOrderId is not provided, set it to 0
            };
        }

        public static ReviewHomeChefOrderDetailsVM ToDetailsViewModel(this ReviewHomeChefOrder reviewHomeChefOrder)
        {
            return new ReviewHomeChefOrderDetailsVM
            {
                Comments = reviewHomeChefOrder.Comments,
                Rating = reviewHomeChefOrder.Rating,
                ModificationDateTime = reviewHomeChefOrder.ModificationDateTime
            };
        }
    }
}
