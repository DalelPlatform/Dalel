using Dalel.Repository;
using Dalel.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Driver;
using Models.Enums;

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

        public IQueryable<BookingVehicle> GetBookingsByStatus(BookingStatus status)
        {
            return GetList(b => b.BookingStatus == status);
        }

        public IQueryable<BookingVehicle> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return base.GetList();

            searchTerm = searchTerm.ToLower();

            return base.GetList()
                .Where(b =>
                    b.Client.User.UserName.ToLower().Contains(searchTerm) ||
                    b.Client.User.Email.ToLower().Contains(searchTerm) ||
                    b.BookingStatus.ToString().ToLower().Contains(searchTerm) ||
                    b.PickupLocation.ToLower().Contains(searchTerm) ||
                    b.DropoffLocation.ToLower().Contains(searchTerm) ||
                    b.Id.ToString().Contains(searchTerm)
                );
        }
    }
}
