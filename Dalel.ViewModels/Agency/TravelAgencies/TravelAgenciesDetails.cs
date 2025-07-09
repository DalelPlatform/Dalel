using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Models.Enums;

namespace Dalel.ViewModels.Agency.TravelAgencies
{
    public class TravelAgenciesDetails
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string Description { get; set; }
        public string ContactInfo { get; set; }
        public string BusinessCategory { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int BuildingNo { get; set; }
        public string Street { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public VerificationStatus VerificationStatus { get; set; }
        public List<addAgencyVerificationDocumentVM> VerificationDocument { get; set; }
    }
}
