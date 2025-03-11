using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Agency
{
    public class PackageBookingReview
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int Rating { get; set; }
   public string Comment { get; set; }
        public int BookingId { get; set; }
        public PackageBooking PackageBooking { get; set; }
    }
}
