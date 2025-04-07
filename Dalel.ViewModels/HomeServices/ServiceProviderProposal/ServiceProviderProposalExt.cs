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
                SuggestedPrice = vm.SuggestedPrice,
                Description = vm.Description,
                Status = ProposalStatus.Pending
            };
        }

        public static ServiceProviderProposalDetailsVM ToDetailsModel(this ServiceProviderPropsal model)
        {
            return new ServiceProviderProposalDetailsVM
            {
                ProviderName = model.ServiceProvider?.AppUser.UserName ?? string.Empty,
                SuggestedPrice = model.SuggestedPrice,
                Description = model.Description,
                Status = model.Status
            };
        }
    }
}
