using Dalel.Repository;
using Dalel.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Driver;
using System.Linq;

namespace Dalel.Reopsitory
{
    public class ReviewVehicleRepository : BaseRepository<ReviewVehicle>
    {
        public ReviewVehicleRepository(DelelContext context) : base(context) { }

        
        public ReviewVehicleDetailsViewModel GetReviewWithDetails(int reviewId)
        {
            return base.GetList(r => r.Id == reviewId).Select(b => b.ToViewModel()).FirstOrDefault();
        }

        
        public decimal GetAverageRating()
        {
            return base.GetList().Any() ? base.GetList().Average(r => r.Rating) : 0;
        }

        
        public IQueryable<ReviewVehicleDetailsViewModel> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return base.GetList().Select(r => r.ToViewModel());

            searchTerm = searchTerm.ToLower();

            return base.GetList().Where(r =>
                r.BookingVehicle.Client.User.UserName.ToLower().Contains(searchTerm) ||
                r.Id.ToString().Contains(searchTerm)
            ).Select(r => r.ToViewModel());
        }
    }
}