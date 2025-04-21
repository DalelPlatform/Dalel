using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
using Models.Agency;

namespace Dalel.ViewModels
{
    public static class PackagebookingExt
    {
        public static PackageBooking ToModel(this AddPackagebookingVM book)
        {
            return new PackageBooking
            {
               BookingStatus = book.BookingStatus,
               Date = book.Date,
               ReservedPeople = book.ReservedPeople,
               TotalPrice = book.TotalPrice,


            };


        }
        public static PackagebookingDetails ToDetailsModels(this
            PackageBooking book)
        {
            return new PackagebookingDetails
            {
                Id = book.Id,
                BookingStatus = book.BookingStatus,
                Date = book.Date,
                ReservedPeople = book.ReservedPeople,
                TotalPrice = book.TotalPrice,

            };
        }
    }
}
