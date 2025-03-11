using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency.Enums;
using Models.Driver;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models.Agency
{
    //   ClientId int[ref: > Clients.UserId]
    //   PackageSchaduleId int[ref: > PackageSchadules.Id]

    public class PackageBooking
    {
        public int Id { get; set; }
        public VerificationStatus PaymentStatus { get; set; }
        public DateTime Date { get; set; }
        public int ReservedPeople { get; set; }
        public float TotalPrice { get; set; }
        public int PackageSchaduleId { get; set; }
        public PackageSchadule PackageSchadule { get; set; }
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
        public ICollection<PackageBookingPayment> Payment { get; set; }
        public ICollection <PackageBookingReview > Review { get; set; }
    }
}
