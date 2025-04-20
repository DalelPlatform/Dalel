using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel.HotelVM
{
    using Models.Hotel;
    using System.Collections.Generic;

    namespace Dalel.ViewModels
    {
        public class HotelSearchResponse
        {
            public int HotelId { get; set; }
            public string Name { get; set; }
            public string City { get; set; }
            public decimal CheapestPrice { get; set; }
            public List<Service> services { get; set; }
            public List<string> ImageUrls { get; set; }
            public bool HasCancellation { get; set; }
            public float AverageRating { get; set; }
            public string VerificationStatus { get; set; }
        }
    }
}
