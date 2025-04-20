using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dalel.ViewModels
{
    public static class ServiceProviderPaymentExt
    {
        public static Models.HomeService.ServiceProviderPayment ToModel(this AddServiceProviderPayment vm)
        {
            return new Models.HomeService.ServiceProviderPayment
            {
                Amount = vm.Amount,
                AmountPaid = vm.AmountPaid,
                CommissionDeducted = vm.CommissionDeducted,
                CodeApplied = vm.CodeApplied,
                TransactionDateTime = DateTime.Now,
                PaymentMethod = vm.PaymentMethod,
                PaymentStatus = vm.PaymentStatus,
                RequestId = vm.RequestId

            };
        }

        public static ServiceProviderDetailsVM ToDetailsModel(this Models.HomeService.ServiceProviderPayment model)
        {
            return new ServiceProviderDetailsVM
            {
                PaymentMethod = model.PaymentMethod.ToString(),
                PaymentStatus = model.PaymentStatus.ToString(),
            };
        }
    }
}
