using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency;
using Models;
using Models.Enums;

namespace Dalel.Repository.Agency
{
    public class AgencyPaymentRepo : BaseRepository<PackageBookingPayment>
    {
      
        public AgencyPaymentRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
        //Get Payment Details
        public IQueryable<PackageBookingPayment> GetPaymentByBookingId(int bookingId)
        {
            return base.GetList(payment => payment.BookingId == bookingId);
       
        }
        public bool UpdatePaymentStatus(int paymentId, PaymentStatus newStatus){

            var payment =  base.GetList(p => p.Id == paymentId).FirstOrDefault();
            if (payment == null)
                return false;

            payment.PaymentStatus = newStatus;
             base.Update(payment);
            return true;
        }
        //Apply Discount Code to Payment
        public bool ApplyDiscountCode(int paymentId, string discountCode)
        {
            var payment = base.GetList(p => p.Id == paymentId).FirstOrDefault();
            if (payment == null)
                return false;

            payment.CodeApplied = discountCode;
            base.Update(payment); // Fix: Pass both parameters
            return true;
        }
        //Get Total Revenue from Paid Bookings
        public decimal GetTotalRevenue()
        {
            return  base.GetList(payment => payment.PaymentStatus == PaymentStatus.Completed)
       .Sum(payment => payment.AmountPaid);
        }
    }


}
