using Dalel.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Driver;
using System.Linq;

namespace Dalel.Reopsitory
{
    public class ReviewVehicleRepository : BaseRepository<ReviewVehicle>
    {
        public ReviewVehicleRepository(DelelContext context) : base(context) { }

        
        public ReviewVehicle GetReviewWithDetails(int reviewId)
        {
            return base.GetList(r => r.Id == reviewId).FirstOrDefault();
        }

        
        public decimal GetAverageRating()
        {
            return base.GetList().Any() ? base.GetList().Average(r => r.Rating) : 0;
        }

        
        public IQueryable<ReviewVehicle> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return base.GetList();

            searchTerm = searchTerm.ToLower();

            return base.GetList().Where(r =>
                r.BookingVehicle.Client.User.UserName.ToLower().Contains(searchTerm) ||
                r.Id.ToString().Contains(searchTerm)
            );
        }
    }
}