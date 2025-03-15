using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WeddingPlaces
{
    class WeddingCustomers
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public string Email { get; set; }
        public DateTime WeddingDate { get; set; }
        public int GuestCount { get; set; }
        public float Budget { get; set; }
        public string InquiryStatus { get; set; }
    }
}
