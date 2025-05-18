using Dalel.Repository;
using Dalel.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Driver;
using Models.Enums;
using Models.Restaurant.Enums;

namespace Dalel.Reopsitory
{
    public class BookingVehicleRepository : BaseRepository<BookingVehicle>
    {
        public BookingVehicleRepository(DelelContext context) : base(context)
        {
        }

        public BookingVehicleDetailsViewModel GetBookingWithDetails(int bookingId)
        {
            var booking = base.GetList(b => b.Id == bookingId).FirstOrDefault();
            return booking?.ToDetailsViewModel();
        }

        public IQueryable<BookingVehicleDetailsViewModel> GetBookingsByStatus(BookingStatus status)
        {
            return GetList(b => b.BookingStatus == status).Select(b => b.ToDetailsViewModel());
        }

        public IQueryable<BookingVehicleDetailsViewModel> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return base.GetList().Select(b => b.ToDetailsViewModel());

            searchTerm = searchTerm.ToLower();

            return base.GetList()
                .Where(b =>
                    b.Client.User.UserName.ToLower().Contains(searchTerm) ||
                    b.Client.User.Email.ToLower().Contains(searchTerm) ||
                    b.BookingStatus.ToString().ToLower().Contains(searchTerm) ||
                    b.PickupLocation.ToLower().Contains(searchTerm) ||
                    b.DropoffLocation.ToLower().Contains(searchTerm) ||
                    b.Id.ToString().Contains(searchTerm)
                ).Select(b => b.ToDetailsViewModel());
        }

     
    }
}
