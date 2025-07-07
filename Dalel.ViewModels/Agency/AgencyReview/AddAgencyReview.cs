 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Agency.AgencyReview
{
    public class AddAgencyReview
    {
      
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int BookingId { get; set; }
    }
}
