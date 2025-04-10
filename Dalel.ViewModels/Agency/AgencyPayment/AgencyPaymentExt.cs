using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.PackageBookingPayment;
using Models.Agency;
namespace Dalel.ViewModels
{
    public static class AgencyPaymentExt
    {
        public static Models.Agency.PackageBookingPayment
            ToModel(this AddAgencyPaymentVM packageVM)
        {
            return new PackageBookingPayment
            {
            
                Amount = packageVM.Amount,
                AmountPaid = packageVM.AmountPaid,
                CommissionDeducted = packageVM.CommissionDeducted,
                CodeApplied = packageVM.CodeApplied,
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

            };
        }
    }
    
}
