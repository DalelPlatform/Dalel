using Dalel.ViewModels;
using LinqKit;
using Models;
using Models.Enums;
using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class BookingPropertiesRepository : BaseRepository<BookingProperties>
    {
        public BookingPropertiesRepository(DelelContext context) : base(context)
        {

        }
        public PaginationViewModel<BookingPropertiesDetailsVM> SearchProperties(
          string searchText = "",
          int pageSize = 4,
           int pageIndex = 1)
        {
            var builder = PredicateBuilder.New<BookingProperties>();

            var old = builder;

            if (!string.IsNullOrEmpty(searchText))
                builder = builder.And(r => r.Status.ToString().Contains(searchText));
                builder = builder.And(r => r.Client.User.UserName.Contains(searchText));

            var count = base.GetList(builder).Count();

            var query = base.GetList(builder);

            var resultAfterPagination = base.Get(
                filter: builder,
                pageSize: pageSize,
                pageNumber: pageIndex).Select(p => p.ToDetailsViewModel()).ToList();

            return new PaginationViewModel<BookingPropertiesDetailsVM>
            {
                Data = resultAfterPagination,
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = count
            };
        }
        public BookingProperties GetBookingById(int bookingId)
        {
            return GetList(b => b.Id == bookingId).FirstOrDefault();
        }

        public IQueryable<BookingProperties> GetBookingsByClient(string clientId)
        {
            return GetList(b => b.ClientId == clientId);
        }

        public IQueryable<BookingProperties> GetBookingsByProperty(int propertyId)
        {
            return GetList(b => b.PropertyId == propertyId);
        }

        public List<BookingPropertiesDetailsVM> GetAllBookings(string ownerid)
        {
            return GetList(b => b.Properties.OwnerId == ownerid).Select(p => p.ToDetailsViewModel()).ToList();
        }

        public IQueryable<BookingProperties> GetActiveBookings()
        {
            return GetList(b => b.Status != BookingStatus.Rejected);
        }

        public List<BookingPropertiesDetailsVM> GetBookingsByStatus(BookingStatus status, string ownerid)
        {
            return GetList(b => b.Status == status && b.Properties.OwnerId == ownerid).Select(p => p.ToDetailsViewModel()).ToList();
        }

        public IQueryable<BookingProperties> GetBookingsByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetList(b => b.CheckIn >= startDate && b.CheckOut <= endDate);
        }

        public void UpdateBookingStatus(int bookingId, BookingStatus status)
        {
            var booking = GetList(b => b.Id == bookingId).FirstOrDefault();
            if (booking != null)
            {
                booking.Status = status;
                Update(booking); 
            }
        }
        public void CancelBooking(int bookingId)
        {
            var booking = GetList(b => b.Id == bookingId).FirstOrDefault();
            if (booking != null)
            {
                booking.Status = BookingStatus.Rejected;
                Update(booking);
            }
        }
        public IQueryable<BookingPropertiesDetailsVM> GetPendingBooking()
        {
            return GetList(p => p.Status == BookingStatus.Panding).
                Select(book => book.ToDetailsViewModel());
        }
     

    }
}
