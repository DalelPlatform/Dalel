using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
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

                //AgencyPackages = book.AgencyPackage.Select(i => i.ToModel()).ToList(),
                //agencyPromotions = book.AgencyPromotion.Select(i => i.ToModel()).ToList(),
                AgencyVerificationDocuments = book.VerificationDocument.
                Select(i => i.ToModel()).ToList(),
               
                OwnerId = book.ownerId,

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
                VerificationDocument = book.AgencyVerificationDocuments.
                Select(i =>new addAgencyVerificationDocumentVM
                {
                    DocumentType = i.DocumentType,
                    DocumentFileName = i.DocumentFile,
                    status=i.status,
                    AgencyId = i.AgencyId
                }).ToList(),

            };
        }
        public static TravelAgencies ToEditModel(this addTravelAgenciesVM book,
            TravelAgencies old)
        {

            old.BusinessName = string.IsNullOrEmpty(book.BusinessName) ? 
                old.BusinessName : book.BusinessName;
            old.VerificationStatus = book.VerificationStatus 
                == old.VerificationStatus ? old.VerificationStatus : book.VerificationStatus;
            old.Description = book.Description;
            old.Latitude = book.Latitude;
            old.Longitude = book.Longitude;
            old.Street = book.Street;
            old.BuildingNo = book.BuildingNo;
            old.City = book.City;
            old.Address = book.Address;
            old.BusinessCategory = book.BusinessCategory;
            old.ContactInfo = book.ContactInfo;

            if (book.keepPrevious == false)
            {
                old.AgencyVerificationDocuments.Clear();
            }
            old.AgencyVerificationDocuments = new List<AgencyVerificationDocument>();
            foreach (var item in book.VerificationDocument)
            {
                old.AgencyVerificationDocuments.Add(new AgencyVerificationDocument()
                {
                   DocumentFile = item.DocumentFileName??"",
                    DocumentType = item.DocumentType,
                    status = item.status,
                    //AgencyId = item.AgencyId,


                });
            }

            return old;
        }

    }

}