using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyReview;
using Models.Agency;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dalel.ViewModels
{
    public static class  AgencyReviewExe
    {
        public static PackageBookingReview  ToModel(this AddAgencyReview review)
        {
            return new PackageBookingReview
            {
              date = review.date,
              Rating = review.Rating,
              Comment = review.Comment,
              BookingId = review.BookingId, 

            };


        }
        public static AgencyReviewDetails ToDetailsModels(this PackageBookingReview review)
        {
            return new AgencyReviewDetails
            {
                Id = review.Id,
                date = review.date,
                Rating = review.Rating,
                Comment = review.Comment,
                BookingId = review.BookingId,

            };
        }
        public static PackageBookingReview ToEditModel(this AddAgencyReview review,
        PackageBookingReview old)
        {
            old.date = review.date;
            old.Rating = review.Rating;
            old.Comment = review.Comment;
            old.BookingId = review.BookingId;
           
            return old;
        }
    }
}
