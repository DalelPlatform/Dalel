using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.Packagebooking;
using LinqKit;
using Models;
using Models.Agency;
using Models.Enums;

namespace Dalel.Repository.Agency
{
    public class PackagebookingRepo : BaseRepository<PackageBooking>
    {
        public PackagebookingRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
        //Get All Bookings for a Client

        public IQueryable<PackageBooking> GetBookingsByClient(string clientId)
        {
            return GetList(booking => booking.ClientId == clientId)
                .OrderByDescending(booking => booking.Date);

        }
        public IQueryable<PackageBooking> GetCompletedBookings(string clientId)
        {
            return GetList(booking => booking.ClientId == clientId &&
        booking.PackageSchadule.Date <= DateTime.Now).
               OrderByDescending(booking => booking.PackageSchadule.Date);



        }
        public bool CancelBooking(int bookingId)
        {
            var booking = GetList(b => b.Id == bookingId)

                .FirstOrDefault();

            if (booking == null || booking.PackageSchadule.Date <= DateTime.UtcNow)
            {
                return false;
            }
            booking.BookingStatus = BookingStatus.Rejected;
            Update(booking);
            return true;
        }



        //searching 

        public PaginationViewModel<PackagebookingDetails> SearchMenuItem(
        string searchText = "",
        BookingStatus Status = BookingStatus.Confirmed,//add all enum
        DateTime? date = null,
        int pageSize = 10,
        int pageIndex = 1,
        string sortBy = "Date",
        bool descending = false)
        {
            var predicate = PredicateBuilder.New<PackageBooking>(true);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(b =>
                    b.Client.User.FirstName.Contains(searchText));  // Assuming there's a related Customer


            }

            if (Status != BookingStatus.All) // Assuming you have an "All" in enum
            {
                predicate = predicate.And(b => b.BookingStatus == Status);
            }



            if (date.HasValue)
            {
                predicate = predicate.And(b => b.Date.Date == date.Value.Date);
            }
            var query = base.GetList(predicate);


            var totalCount = query.Count();

            query = sortBy.ToLower() switch
            {
                "date" => descending ? query.OrderByDescending(b => b.Date) : query.OrderBy(b => b.Date),
                "status" => descending ? query.OrderByDescending(b => b.BookingStatus) : query.OrderBy(b => b.BookingStatus),
                _ => descending ? query.OrderByDescending(b => b.Id) : query.OrderBy(b => b.Id)
            };

            var items = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(b => b.ToDetailsModels()).ToList();
                ;

            return new PaginationViewModel<PackagebookingDetails>
            {
                Data = items,
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };



        }




    }
}
