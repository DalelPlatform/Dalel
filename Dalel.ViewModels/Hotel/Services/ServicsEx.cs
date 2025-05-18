using Models.Hotel;

namespace Dalel.ViewModels
{
    public static class ServiceEx
    {
        // ViewModel → Model (Create)
        public static Service ToModel(this ServiceCreation vm)
        {
            return new Service
            {
                Name = vm.Name,
                Description = vm.Description,
                IsActive = vm.IsActive
            };
        }

        // ViewModel → Update existing Model
        public static void UpdateModel(this Service model, ServiceCreation vm)
        {
            model.Name = vm.Name;
            model.Description = vm.Description;
            model.IsActive = vm.IsActive;
        }

        // Model → ViewModel
        public static ServiceDetails ToDetailsViewModel(this Service model)
        {
            return new ServiceDetails
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                IsActive = model.IsActive
            };
        }
    }
}
