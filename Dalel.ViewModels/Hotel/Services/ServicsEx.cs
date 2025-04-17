using Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Hotel.Services
{
    public static class ServiceViewModelExtensions
    {
        public static ServiceDetails ToServiceDetailsViewModel(this Service service)
        {
            if (service == null)
            {
                return null;
            }

            return new ServiceDetails
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                IsActive = service.IsActive,
                CreatedBy = service.CreatedBy,
                CreatedDate = service.CreatedDate,
                ModifiedBy = service.ModifiedBy,
                ModifiedDate = service.ModifiedDate
            };
        }

        public static Service ToService(this ServiceCreation model)
        {
            if (model == null)
            {
                return null;
            }
            return new Service
            {
                Name = model.Name,
                Description = model.Description,
                IsActive = model.IsActive,


                CreatedBy = "CurrentUser",
                CreatedDate = DateTime.Now,
            };
        }
    }

}
