using Dalel.Repository;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Restaurant;
using System.Security.Claims;
using Utilities;

namespace Dalel.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepo;

        public RestaurantService(RestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }

        [Authorize(Roles = "RestaurantOwner")]
        public async Task<ServiceResult> CreateRestaurant([FromForm]AddRestaurantVM vm)
        {
            try
            {
                var model = vm.ToModel();
                _restaurantRepo.Add(model);
                return ServiceResult.SuccessResult("Restaurant added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public async Task<ServiceResult> EditRestaurant(AddRestaurantVM model,int id)
        {
            try
            {
                var oldrestaurant = _restaurantRepo.GetById(id);
                _restaurantRepo.Update(model.ToEditModel(oldrestaurant));
                return ServiceResult.SuccessResult("Restaurant updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public async Task<ServiceResult> DeleteRestaurant(int id)
        {
            try
            {
                var restaurant = _restaurantRepo.GetById(id);
                if (restaurant == null)
                    return ServiceResult.FailureResult("Restaurant not found.");

                _restaurantRepo.Delete(restaurant);
                return ServiceResult.SuccessResult("Restaurant deleted successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult("Error: " + ex.Message);
            }
        }

        public async Task<ServiceResult<List<RestaurantDetailsVM>>> GetAll()
        {
            try
            {
                var list = _restaurantRepo.GetList(r => !r.IsDeleted)
                    .Select(r => r.ToDetailsViewModel())
                    .ToList();

                return ServiceResult<List<RestaurantDetailsVM>>.SuccessResult(list, "Restaurants retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<RestaurantDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

        public ServiceResult<PaginationViewModel<RestaurantDetailsVM>> Search(
            string searchText = "",
            string city = null,
            string region = null,
            string street = null,
            string address = null,
            int NumberOfRooms = 0,
            VerificationStatus? verificationStatus = null,
            string sortBy = "Name",
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            try
            {
                var result = _restaurantRepo.SearchRestaurants(
                    searchText, city, region,street,address,NumberOfRooms, verificationStatus,
                    sortBy, descending, pageSize, pageIndex);

                return ServiceResult<PaginationViewModel<RestaurantDetailsVM>>.SuccessResult(result, "Search completed.");
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<RestaurantDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }
        public async Task<ServiceResult<RestaurantDetailsVM>> GetRestaurantById(int id)
        {
            try
            {
                var restaurant = _restaurantRepo.GetById(id);
                if (restaurant == null)
                    return ServiceResult<RestaurantDetailsVM>.FailureResult("Restaurant not found.");
                return ServiceResult<RestaurantDetailsVM>.SuccessResult(restaurant.ToDetailsViewModel(), "Restaurant retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RestaurantDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }
        public ServiceResult<RestaurantDetailsVM> GetRestaurantByOwnerId(string ownerId)
        {
            try
            {
                var restaurant = _restaurantRepo.GetRestaurantByOwnerId(ownerId);
                if (restaurant == null)
                    return ServiceResult<RestaurantDetailsVM>.FailureResult("Restaurant not found.");
                return ServiceResult<RestaurantDetailsVM>.SuccessResult(restaurant, "Restaurant retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RestaurantDetailsVM>.FailureResult("Error: " + ex.Message);
            }
        }
        public async Task<ServiceResult<List<RestaurantDetailsVM>>> GetRestaurantsByVerificationStatus(VerificationStatus verificationStatus)
        {
            try
            {
                var restaurants = _restaurantRepo.GetRestaurantsByVerificationStatus(verificationStatus)
                    .ToList(); // Convert IQueryable to List to resolve the type mismatch

                if (restaurants == null || !restaurants.Any())
                    return ServiceResult<List<RestaurantDetailsVM>>.FailureResult("No restaurants found with the specified verification status.");

                return ServiceResult<List<RestaurantDetailsVM>>.SuccessResult(restaurants, "Restaurants retrieved.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<RestaurantDetailsVM>>.FailureResult("Error: " + ex.Message);
            }
        }

    }
}
