using System;
using Dalel.ViewModels;
using Dalel.Repository;
using Dalel.ViewModels.Agency.AgencyReview;
using Dalel.ViewModels.Restaurant;
using Utilities;
using Dalel.Repository.Agency;
using Dalel.Reopsitory;

namespace Dalel.Services.Reviews
{
    public class ReviewService
    {
        private readonly PackageBookingReviewRepo _agencyRepo;
        private readonly ReviewVehicleRepository _vehicleRepo;
        private readonly ReviewHomeChefOrderRepository _homeChefRepo;
        private readonly ServiceProviderReviewRepository _serviceProviderRepo;
        private readonly ReviewHotelRoomRepository _hotelRepo;
        private readonly ReviewPropertiesRepository _propertyRepo;
        private readonly ReviewRestaurantOrderRepository _restaurantRepo;

        public ReviewService(
            PackageBookingReviewRepo agencyRepo,
        ReviewVehicleRepository vehicleRepo,
            ReviewHomeChefOrderRepository homeChefRepo,
            ServiceProviderReviewRepository serviceProviderRepo,
            ReviewHotelRoomRepository hotelRepo,
            ReviewPropertiesRepository propertyRepo,
            ReviewRestaurantOrderRepository restaurantRepo)
        {
            _agencyRepo = agencyRepo;
            _vehicleRepo = vehicleRepo;
            _homeChefRepo = homeChefRepo;
            _serviceProviderRepo = serviceProviderRepo;
            _hotelRepo = hotelRepo;
            _propertyRepo = propertyRepo;
            _restaurantRepo = restaurantRepo;
        }

        #region Agency Reviews
        public ServiceResult CreateAgencyReview(AddAgencyReview vm)
        {
            try
            {
                var model = vm.ToModel();
                _agencyRepo.Add(model);
                return ServiceResult.SuccessResult("Agency review created successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error creating agency review: " + ex.Message);
            }
        }

        public ServiceResult EditAgencyReview(int id, AddAgencyReview vm)
        {
            try
            {
                var existing = _agencyRepo.GetById(id);
                var model = vm.ToModel();
                model.Id = id;
                _agencyRepo.Update(model);
                return ServiceResult.SuccessResult("Agency review updated successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating agency review: " + ex.Message);
            }
        }

        public ServiceResult DeleteAgencyReview(int id)
        {
            try
            {
                var model = _agencyRepo.GetById(id);
                _agencyRepo.Delete(model);
                return ServiceResult.SuccessResult("Agency review deleted successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting agency review: " + ex.Message);
            }
        }
        #endregion

        #region Vehicle Reviews
        public ServiceResult CreateVehicleReview(AddReviewVehicle vm)
        {
            try
            {
                var model = vm.ToModel();
                _vehicleRepo.Add(model);
                return ServiceResult.SuccessResult("Vehicle review created successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error creating vehicle review: " + ex.Message);
            }
        }

        public ServiceResult EditVehicleReview(int id, AddReviewVehicle vm)
        {
            try
            {
                var model = vm.ToModel();
                model.Id = id;
                _vehicleRepo.Update(model);
                return ServiceResult.SuccessResult("Vehicle review updated successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating vehicle review: " + ex.Message);
            }
        }

        public ServiceResult DeleteVehicleReview(int id)
        {
            try
            {
                var model = _vehicleRepo.GetById(id);
                _vehicleRepo.Delete(model);
                return ServiceResult.SuccessResult("Vehicle review deleted successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting vehicle review: " + ex.Message);
            }
        }
        #endregion

        #region Home Chef Order Reviews
        public ServiceResult CreateHomeChefReview(AddReviewHomeChefOrderVM vm)
        {
            try
            {
                var model = vm.ToModel();
                _homeChefRepo.Add(model);
                return ServiceResult.SuccessResult("Home chef order review created successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error creating home chef review: " + ex.Message);
            }
        }

        public ServiceResult EditHomeChefReview(int id, AddReviewHomeChefOrderVM vm)
        {
            try
            {
                var model = vm.ToModel();
                model.Id = id;
                _homeChefRepo.Update(model);
                return ServiceResult.SuccessResult("Home chef order review updated successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating home chef review: " + ex.Message);
            }
        }

        public ServiceResult DeleteHomeChefReview(int id)
        {
            try
            {
                var model = _homeChefRepo.GetById(id);
                _homeChefRepo.Delete(model);
                return ServiceResult.SuccessResult("Home chef order review deleted successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting home chef review: " + ex.Message);
            }
        }
        #endregion

        #region Service Provider Reviews
        public ServiceResult CreateServiceProviderReview(AddServiceProviderReviewVM vm)
        {
            try
            {
                var model = vm.ToModel();
                _serviceProviderRepo.Add(model);
                return ServiceResult.SuccessResult("Service provider review created successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error creating service provider review: " + ex.Message);
            }
        }

        public ServiceResult EditServiceProviderReview(int id, AddServiceProviderReviewVM vm)
        {
            try
            {
                var model = vm.ToModel();
                model.Id = id;
                _serviceProviderRepo.Update(model);
                return ServiceResult.SuccessResult("Service provider review updated successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating service provider review: " + ex.Message);
            }
        }

        public ServiceResult DeleteServiceProviderReview(int id)
        {
            try
            {
                var model = _serviceProviderRepo.GetById(id);
                _serviceProviderRepo.Delete(model);
                return ServiceResult.SuccessResult("Service provider review deleted successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting service provider review: " + ex.Message);
            }
        }
        #endregion

        #region Hotel Room Reviews
        public ServiceResult CreateHotelReview(ReviewCreation vm)
        {
            try
            {
                var model = vm.ToModel();
                _hotelRepo.Add(model);
                return ServiceResult.SuccessResult("Hotel review created successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error creating hotel review: " + ex.Message);
            }
        }

        public ServiceResult EditHotelReview(int id, ReviewCreation vm)
        {
            try
            {
                var model = vm.ToModel();
                model.Id = id;
                _hotelRepo.Update(model);
                return ServiceResult.SuccessResult("Hotel review updated successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating hotel review: " + ex.Message);
            }
        }

        public ServiceResult DeleteHotelReview(int id)
        {
            try
            {
                var model = _hotelRepo.GetById(id);
                _hotelRepo.Delete(model);
                return ServiceResult.SuccessResult("Hotel review deleted successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting hotel review: " + ex.Message);
            }
        }
        #endregion

        #region Property Reviews
        public ServiceResult CreatePropertyReview(AddReviewPropertiesVM vm)
        {
            try
            {
                var model = vm.ToModel();
                _propertyRepo.Add(model);
                return ServiceResult.SuccessResult("Property review created successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error creating property review: " + ex.Message);
            }
        }

        public ServiceResult EditPropertyReview(int id, AddReviewPropertiesVM vm)
        {
            try
            {
                var model = vm.ToModel();
                model.Id = id;
                _propertyRepo.Update(model);
                return ServiceResult.SuccessResult("Property review updated successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating property review: " + ex.Message);
            }
        }

        public ServiceResult DeletePropertyReview(int id)
        {
            try
            {
                var model = _propertyRepo.GetById(id);
                _propertyRepo.Delete(model);
                return ServiceResult.SuccessResult("Property review deleted successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting property review: " + ex.Message);
            }
        }
        #endregion

        #region Restaurant Order Reviews
        public ServiceResult CreateRestaurantReview(AddReviewRestaurantOrderVM vm)
        {
            try
            {
                var model = vm.ToModel();
                _restaurantRepo.Add(model);
                return ServiceResult.SuccessResult("Restaurant review created successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error creating restaurant review: " + ex.Message);
            }
        }

        public ServiceResult EditRestaurantReview(int id, AddReviewRestaurantOrderVM vm)
        {
            try
            {
                var model = vm.ToModel();
                model.Id = id;
                _restaurantRepo.Update(model);
                return ServiceResult.SuccessResult("Restaurant review updated successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error updating restaurant review: " + ex.Message);
            }
        }

        public ServiceResult DeleteRestaurantReview(int id)
        {
            try
            {
                var model = _restaurantRepo.GetById(id);
                _restaurantRepo.Delete(model);
                return ServiceResult.SuccessResult("Restaurant review deleted successfully.", 200);
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error deleting restaurant review: " + ex.Message);
            }
        }
        #endregion
    }
}
