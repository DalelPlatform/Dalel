using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency.Enums;

namespace Models.Agency
{
    public class PackageBookingPayment
    {
        public int Id { get; set; }
        public float Amount     { get; set; }
  public decimal AmountPaid { get; set; }

  public decimal CommissionDeducted { get; set; }
public string CodeApplied { get; set; }
        public string PaymentMethod {  get; set; }

 public  DateTime date {  get; set; }

        public VerificationStatus status { get; set; }
        public int BookingId    { get; set; }
        public PackageBooking PackageBooking { get; set; }
    }
}
