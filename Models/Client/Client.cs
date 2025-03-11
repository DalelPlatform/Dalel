using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency;

namespace Models.Driver
{
    public class Client
    {
        public string Id { get; set; }


        public string FullName { get; set; }


        public string PhoneNumber { get; set; }


        public string Email { get; set; }


        public string Address { get; set; }

        public virtual ICollection<BookingVehicle> BookingVehicles { get; set; }
        public virtual ICollection<PaymentVehicle> Payments { get; set; }
        public virtual ICollection<ReviewVehicle> Reviews { get; set; }
        public ICollection<PackageBooking> packageBookings { get; set; }
        public ICollection<Agency_CustomerInquiry> AgencyInquiry { get; set; }
    }
}
