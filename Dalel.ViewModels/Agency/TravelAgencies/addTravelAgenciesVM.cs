using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.PackageSchadule;
using Dalel.ViewModels.Agency.PackageStep;
using Models.Enums;

namespace Dalel.ViewModels.Agency.TravelAgencies
{
    public class addTravelAgenciesVM
    {
        [Required(ErrorMessage = "Please Provide valid BusinessName")]

        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Please Provide valid Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Provide valid ContactInfo")]
        public string ContactInfo { get; set; }

        [Required(ErrorMessage = "Please Provide valid BusinessCategory")]
        public string BusinessCategory { get; set; }

        [Required(ErrorMessage = "Please Provide valid Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Provide valid City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Provide valid BuildingNo")]
        public int BuildingNo { get; set; }

        [Required(ErrorMessage = "Please Provide valid Street")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Please Provide valid Latitude")]
        public float Latitude { get; set; }

        [Required(ErrorMessage = "Please Provide valid Longitude")]
        public float Longitude { get; set; }

        [Required(ErrorMessage = "Please Provide valid Status")]
        public VerificationStatus VerificationStatus { get; set; }
        public List<AddAgencyPackageVM> AgencyPackage { get; set; }
        public List<addAgencyVerificationDocumentVM> VerificationDocument { get; set; }
        public List<AddAgencyPromotionVM> AgencyPromotion { get; set; }

        public string ownerId { get; set; } = "";
    }
}