using Models.Enums;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ServiceRequestExt
    {
        public static ServiceRequest ToModel(this AddServiceRequestVM vm)
        {
            return new ServiceRequest
            {
                ClientId = vm.ClientId,
                Title = vm.Title,
                CategoryServicesId = vm.CategoryServicesId,
                Description = vm.Description,
                Address =vm.Address,
                Date = vm.Date,
                Status = vm.Status,
                DueDate = vm.DueDate,
                Image = vm.Image != null ? $"/images/servicerequest/{vm.Date}/{vm.ClientId}/{vm.Image.FileName}" : null,
                StartPrice = vm.StartPrice,

                
            };
        }

        public static ServiceRequest ToEditModel(this AddServiceRequestVM vm, ServiceRequest existing)
        {
            existing.ClientId = vm.ClientId;
            existing.Title = vm.Title;
            existing.CategoryServicesId = vm.CategoryServicesId;
            existing.Description = vm.Description;
            existing.Address = vm.Address;
            existing.Date = vm.Date;
            existing.Status = vm.Status;
            existing.DueDate = vm.DueDate;
            existing.Image = vm.Imagepath ?? existing.Image;
            existing.StartPrice = vm.StartPrice;

            
            return existing;
        }

        public static ServiceRequestDetailsVM ToDetailsViewModel(this ServiceRequest model)
        {
            return new ServiceRequestDetailsVM
            {
                Id = model.Id,
                Title = model.Title,
                ClientId = model.ClientId,
                CategoryServicesId = model.CategoryServicesId,
                Description = model.Description,
                Address = model.Address,
                Date = model.Date,
                Status = model.Status,
                DueDate = model.DueDate,
                Image = model.Image,
                StartPrice = model.StartPrice,
            };
        }
    }
}
