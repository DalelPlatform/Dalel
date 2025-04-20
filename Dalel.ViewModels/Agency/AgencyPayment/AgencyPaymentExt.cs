using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.PackageBookingPayment;
using Dalel.ViewModels.Agency.TravelAgencies;
using Models.Agency;
namespace Dalel.ViewModels
{
    public static class AgencyPaymentExt
    {
        public static PackageBookingPayment ToModel(this AddAgencyPaymentVM packageVM)
        {
            return new PackageBookingPayment
            {
                Amount = packageVM.Amount,
                AmountPaid = packageVM.AmountPaid,
                CommissionDeducted = packageVM.CommissionDeducted,
                CodeApplied = packageVM.CodeApplied,
                PaymentMethod = packageVM.PaymentMethod,
                PaymentStatus = packageVM.PaymentStatus,
                BookingId = packageVM.BookingId,
            };


        }
        public static AgencyPaymentDetails 
            ToDetailsModels(this PackageBookingPayment package)
        {
            return new AgencyPaymentDetails
            {
                id = package.Id,
                Amount = package.Amount,
                AmountPaid = package.AmountPaid,
                CommissionDeducted = package.CommissionDeducted,
                CodeApplied = package.CodeApplied,
                PaymentMethod = package.PaymentMethod,
                PaymentStatus = package.PaymentStatus,
                BookingId = package.BookingId,

            };
        }

        public static PackageBookingPayment ToEditModel(this AddAgencyPaymentVM pay, PackageBookingPayment old)
        {

            old.CodeApplied = string.IsNullOrEmpty(pay.CodeApplied) ? old.CodeApplied : pay.CodeApplied;
            old.PaymentStatus = pay.PaymentStatus == old.PaymentStatus ? old.PaymentStatus : pay.PaymentStatus;
            old.Amount = pay.Amount;
            old.AmountPaid = pay.AmountPaid;
            old.CommissionDeducted = pay.CommissionDeducted;
            old.PaymentMethod = pay.PaymentMethod;

        


            return old;
        }


    }

}
