using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels.Agency.TravelAgencies;
using Models.Agency;
using Models.Enums;

namespace Dalel.ViewModels
{
    public static class TravelAgenciesExt
    {
        public static TravelAgencies ToModel(this addTravelAgenciesVM book)
        {
            return new TravelAgencies
            {
                BusinessName = book.BusinessName,
                VerificationStatus = book.VerificationStatus,
                Description = book.Description,
                Latitude = book.Latitude,
                Longitude = book.Longitude,
                Street = book.Street,
                BuildingNo = book.BuildingNo,
                City = book.City,
                Address = book.Address,
                BusinessCategory = book.BusinessCategory,
                ContactInfo = book.ContactInfo,
                




            };


        }
        public static TravelAgenciesDetails ToDetailsModels(this
            TravelAgencies book)
        {
            return new TravelAgenciesDetails
            {
                Id = book.Id,
                BusinessName = book.BusinessName,
                VerificationStatus = book.VerificationStatus,
                Description = book.Description,
                Latitude = book.Latitude,
                Longitude = book.Longitude,
                Street = book.Street,
                BuildingNo = book.BuildingNo,
                City = book.City,
                Address = book.Address,
                BusinessCategory = book.BusinessCategory,
                ContactInfo = book.ContactInfo,


            };
        }
    }

}
