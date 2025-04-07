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
        public static Models.HomeService.ServiceProviderPayment ToModel(this ServiceProviderDetailsVM vm)
        {
            return new Models.HomeService.ServiceProviderPayment
            {
                PaymentMethod = Enum.Parse<PaymentMethod>(vm.PaymentMethod),
                PaymentStatus = Enum.Parse<PaymentStatus>(vm.PaymentStatus),
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
