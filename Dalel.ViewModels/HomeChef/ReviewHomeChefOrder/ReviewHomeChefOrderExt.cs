using Dalel.ViewModels;
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


        public static ReviewHomeChefOrder ToEditModel(this AddReviewHomeChefOrderVM addVM, ReviewHomeChefOrder old)
        {
            old.Comments = !string.IsNullOrWhiteSpace(addVM.Comments)
                ? addVM.Comments
                : old.Comments;

            old.Rating = addVM.Rating > 0
                ? addVM.Rating
                : old.Rating;

            old.ModificationDateTime = addVM.ModificationDateTime != default(DateTime)
                ? addVM.ModificationDateTime
                : DateTime.Now;

            old.HomeChefOrderId = addVM.HomeChefOrderId.HasValue && addVM.HomeChefOrderId > 0
                ? addVM.HomeChefOrderId.Value
                : old.HomeChefOrderId;

            return old;
        }

    }
}
