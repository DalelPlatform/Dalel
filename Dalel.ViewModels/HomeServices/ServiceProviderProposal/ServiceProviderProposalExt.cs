using Models.Enums;
using Models.HomeService;
using Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ServiceProviderProposalExt
    {
        public static ServiceProviderPropsal ToModel(this AddServiceProviderProposalVM vm, AppUser serviceProviderUser)
        {
            return new ServiceProviderPropsal
            {
                ServiceProviderId = vm.ServiceProviderId,
                ServiceRequestId = vm.ServiceRequestId,
                Description = vm.Description,
                SuggestedPrice = vm.SuggestedPrice,
                Status = vm.Status,
                ServiceProviderName = serviceProviderUser?.UserName ?? "",
                Date = vm.Date ?? DateTime.Now

            };
        }
        public static ServiceProviderPropsal ToEditModel(this AddServiceProviderProposalVM vm, ServiceProviderPropsal existing)
        {
            existing.ServiceProviderId = vm.ServiceProviderId;
            existing.ServiceRequestId = vm.ServiceRequestId;
            existing.Description = vm.Description;
            existing.SuggestedPrice = vm.SuggestedPrice;
            existing.Status = vm.Status;
            existing.Date = vm.Date ?? DateTime.Now;
            return existing;
        }
        public static ServiceProviderProposalDetailsVM ToDetailsViewModel(this ServiceProviderPropsal model)
        {
            return new ServiceProviderProposalDetailsVM
            {
                Id = model.Id,
                ServiceProviderId = model.ServiceProviderId,
                ServiceRequestId = model.ServiceRequestId,
                Description = model.Description,
                Date = model.Date,
                SuggestedPrice = model.SuggestedPrice,
                Status = model.Status,
                ServiceProviderName = model.ServiceProviderName

            };
        }
    }
}
