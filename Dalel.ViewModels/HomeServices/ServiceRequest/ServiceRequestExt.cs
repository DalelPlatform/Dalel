using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ServiceRequestExt
    {
        public static Models.HomeService.ServiceRequest ToModel(this AddServiceRequestVM vm)
        {
            return new Models.HomeService.ServiceRequest
            {
                ClientId = vm.ClientId,
                Date = DateTime.UtcNow,
                Status = RequestStatus.Pending,
                StartPrice = vm.StartPrice,
                Description = vm.Description,
                Address = vm.Address,
                Image = vm.Image,
                IsDeleted = false
            };
        }

        public static ServiceRequestDetailsVM ToDetailsModel(this Models.HomeService.ServiceRequest model)
        {
            return new ServiceRequestDetailsVM
            {
                //ClientId = model.Id,
                ClientName = model.Client?.User.UserName ?? string.Empty,
                Date = model.Date.ToString("yyyy-MM-dd"),
                Status = model.Status,
                StartPrice = model.StartPrice,
                Description = model.Description,
                Address = model.Address,
                ImageUrl = model.Image,
                ProposalsCount = model.Propsals?.Count ?? 0,
            };
        }
    }
}
