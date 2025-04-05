using Models.Driver;
using Models.ViewModels;

namespace Dalel.Extensions
{
    public static class ReviewVehicleExtensions
    {
        public static ReviewVehicleDetailsViewModel ToViewModel(this ReviewVehicle review)
        {
            return new ReviewVehicleDetailsViewModel
            {
                Id = review.Id,
                Comments = review.Comments,
                Rating = review.Rating,
                ModificationDateTime = review.ModificationDateTime,
                BookingVehicleId = review.BookingVehicleId,
                ClientName = review.BookingVehicle?.Client?.User?.UserName ?? "N/A",
                
            };
        }
    }
}
