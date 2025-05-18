using Models.Enums;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ServiceProviderProposalExt
    {
        public static ServiceProviderPropsal ToModel(this AddServiceProviderProposalVM vm)
        {
            return new ServiceProviderPropsal
            {
                ServiceProviderId = vm.ServiceProviderId,
                ServiceRequestId = vm.ServiceRequestId,
                Description = vm.Description,
                SuggestedPrice = vm.SuggestedPrice,
                Status = vm.Status
            };
        }
        public static ServiceProviderPropsal ToEditModel(this AddServiceProviderProposalVM vm, ServiceProviderPropsal existing)
        {
            existing.ServiceProviderId = vm.ServiceProviderId;
            existing.ServiceRequestId = vm.ServiceRequestId;
            existing.Description = vm.Description;
            existing.SuggestedPrice = vm.SuggestedPrice;
            existing.Status = vm.Status;
            return existing;
        }
        public static ServiceProviderProposalDetailsVM ToDetailsViewModel(this ServiceProviderPropsal model)
        {
            return new ServiceProviderProposalDetailsVM
            {
                Id = model.Id,
                ServiceProviderId = model.ServiceProviderId,
                ServiceProviderName = model.ServiceProvider?.AppUser?.UserName ?? "Not Provided",
                ServiceRequestId = model.ServiceRequestId,
                ServiceRequestDescription = model.ServiceRequest?.Description ?? "Not Provided",
                Description = model.Description,
                SuggestedPrice = model.SuggestedPrice,
                Status = model.Status
            };
        }
    }
}
