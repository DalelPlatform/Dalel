using Models.Enums;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dalel.ViewModels
{
    public static class ServiceProviderPaymentExt
    {
        public static ServiceProviderPayment ToModel(this AddServiceProviderPayment vm)
        {
            return new ServiceProviderPayment
            {
                RequestId = vm.RequestId,
                Amount = (float)vm.Amount,
                PaymentStatus = vm.PaymentStatus
            };
        }

        public static ServiceProviderPayment ToEditModel(this AddServiceProviderPayment vm, ServiceProviderPayment existing)
        {
            existing.RequestId = vm.RequestId;
            existing.Amount = (float)vm.Amount;
            existing.PaymentStatus = vm.PaymentStatus;
            return existing;
        }

        public static ServiceProviderPaymentDetailsVM ToDetailsViewModel(this ServiceProviderPayment model)
        {
            var serviceProviderId = model.ServiceRequest?.Propsals?.FirstOrDefault(p => p.Status == ProposalStatus.Accepted)?.ServiceProviderId;
            return new ServiceProviderPaymentDetailsVM
            {
                Id = model.Id,
                RequestId = model.RequestId,
                ServiceProviderId = serviceProviderId,
                ServiceProviderName = model.ServiceRequest?.Propsals?.FirstOrDefault(p => p.Status == ProposalStatus.Accepted)?.ServiceProvider?.AppUser?.UserName ?? "Not Provided",
                Amount = model.Amount,
                PaymentStatus = model.PaymentStatus
            };
        }
    }
}
