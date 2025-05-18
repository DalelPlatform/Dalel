using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WeddingPlaces
{
    public class PorposalsQuotation
    {
        public string Id { get; set; }
        public string userId { get; set; } // fk AspNetUser.Id
        public string venueId { get; set; } // fk Venues.Id
        public string AdditionalServices { get; set; }
        public string PackageOptions { get; set; }
        public string PorposalStatus { get; set; }
    }
}
