using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Agency;

namespace Dalel.Repository.Agency
{
    public class PackageBookingReviewRepo:BaseRepository<PackageBookingReview>
    {
        public PackageBookingReviewRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
        public IQueryable <PackageBookingReview> GetReviews(int bookingId) {
            return GetList(r => r.BookingId == bookingId);
        }

        public IQueryable<PackageBookingReview> GetReviewsByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetList(r=>r.date >=startDate && r.date <= endDate);
        }

        public double GetAverageRating(int bookingId)
        {
            return GetList(r => r.BookingId == bookingId).
                Select(r=>r.Rating).DefaultIfEmpty(0).Average();
        }
        public IQueryable<PackageBookingReview> GetLatestReviews(int count=5)
        {
            return GetList().OrderByDescending(review => review.date)
            .Take(count); ;
        }


    }
}
