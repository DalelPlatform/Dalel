using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
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




    }
}