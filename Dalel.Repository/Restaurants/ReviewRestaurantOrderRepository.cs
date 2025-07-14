using Models.Restaurant;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;

namespace Dalel.Repository
{
    public class ReviewRestaurantOrderRepository : BaseRepository<ReviewRestaurantOrder>
    {
        public ReviewRestaurantOrderRepository(DelelContext dbContext) : base(dbContext) { }

        public ReviewRestaurantOrderDetailsVM GetReviewByOrder(int orderId)
        {
            return GetList(review => review.RestaurantOrderId == orderId).Select(review => review.ToDetailsViewModel())
                .FirstOrDefault();
        }
        
        public IQueryable<ReviewRestaurantOrderDetailsVM> GetReviewsByRating(float rating)
        {
            return GetList(review => review.Rating == rating).Select(review => review.ToDetailsViewModel());
        }

        //public IQueryable<ReviewRestaurantOrderDetailsVM> GetReviewsByRestaurant(int restaurantId)
        //{
        //    return GetList(review => review.RestaurantOrder.RestaurantId == restaurantId).Select(review => review.ToDetailsViewModel());
        //}
         
        public void AddReview(ReviewRestaurantOrder review)
        {
            Add(review);
    }

        public void RemoveReview(int reviewId)
        {
            var review = GetList(r => r.Id == reviewId).FirstOrDefault();
            if (review != null)
            {
                Delete(review);
            }
        }
    }
}
