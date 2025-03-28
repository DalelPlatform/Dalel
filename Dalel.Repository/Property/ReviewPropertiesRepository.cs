using Dalel.ViewModels;
using Models;
using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class ReviewPropertiesRepository : BaseRepository<ReviewProperties>
    {
        public ReviewPropertiesRepository(DelelContext context) : base(context)
        {
        }
        public IQueryable<ReviewPropertiesDetailsVM> GetReviewByBookingProperty(int bookingPropertyId)
        {
            return GetList(rp => rp.BookingPropertyId == bookingPropertyId).Select(rp => rp.ToDetailsViewModel());
        }

        public IQueryable<ReviewPropertiesDetailsVM> GetReviewsByRating(float rating)
        {
            return GetList(rp => rp.Rating >= rating).Select(rp => rp.ToDetailsViewModel());
        }

        public IQueryable<ReviewPropertiesDetailsVM> GetReviewsWithinDateRange(DateTime startDate, DateTime endDate)
        {
            return GetList(rp => rp.ModificationDateTime >= startDate && rp.ModificationDateTime <= endDate).Select(rp => rp.ToDetailsViewModel());
        }
    }
}
