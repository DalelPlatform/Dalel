using Models.HomeService;
using Models.Restaurant;
using System.Collections.Generic;
using System.Linq;

namespace Dalel.ViewModels
{
    public static class ServiceProviderProjectExt
    {
        public static ServiceProviderProject ToModel(this AddServiceProviderProjectVM vm, string serviceProviderId)
        {
            return new ServiceProviderProject
            {
                Name = vm.Name,
                Description = vm.Description,
                ProjectImages = string.Join(",", vm.ProjectImages.Select(file =>
                {
                    using var stream = new MemoryStream();
                    file.CopyTo(stream);
                    return Convert.ToBase64String(stream.ToArray());
                })),
                ServiceProviderId = serviceProviderId
            };
        }

        public static ServiceProviderProjectDetailsVM ToDetailsModel(this ServiceProviderProject model)
        {
            return new ServiceProviderProjectDetailsVM
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ProjectImages = model.ProjectImages
            };
        }
    }
}