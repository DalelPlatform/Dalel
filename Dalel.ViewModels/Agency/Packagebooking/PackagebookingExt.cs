using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels.Agency.PackageSchadule;
using Models.Agency;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dalel.ViewModels
{
    public static class PackagebookingExt
    {
        public static PackageBooking ToModel(this AddPackagebookingVM book, float TotalPrice)
        {
            return new PackageBooking
            {
                BookingStatus = book.BookingStatus,
                Date = book.Date,
                ReservedPeople = book.ReservedPeople,
                TotalPrice = TotalPrice,
               
                ClientId = book.ClientId,
                
                
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

        public static PackageBooking ToEditModel(this AddPackagebookingVM book,
                PackageBooking old)
        {

            old.BookingStatus = book.BookingStatus;
            old.Date = book.Date;
            old.ReservedPeople = book.ReservedPeople;
            old.TotalPrice = book.TotalPrice;
            return old;
        }
    }
}