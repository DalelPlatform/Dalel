using Dalel.Repository;
using Dalel.ViewModels;
using Models.Enums;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Dalel.Services
{
    public class MealService
    {
        private readonly RestaurantMenuItemRepository menuItemRepository;
        private readonly RestaurantRepository restaurantRepository;
        public MealService(RestaurantMenuItemRepository menuItemRepository, RestaurantRepository restaurantRepository)
        {
            this.menuItemRepository = menuItemRepository;
            this.restaurantRepository = restaurantRepository;
        }

        public ServiceResult<PaginationViewModel<RestaurantMenuItemDetailsVM>> SearchMeals(
            string search = "",
            float? minPrice = null,
            float? maxPrice = null,
            AvaliabilityStatus? avaliabilityStatus = null,
            FoodCategory? foodCategory = null,
            SizeOfPiece? sizeOfPiece = null,
            double? duration = null,
            string sortBy = "Name",
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            try
            {
                var data = menuItemRepository.SearchMeals(
                    search,
                    minPrice,
                    maxPrice,
                    avaliabilityStatus,
                    foodCategory,
                    sizeOfPiece,
                    duration,
                    sortBy,
                    descending,
                    pageSize,
                    pageIndex);

                return ServiceResult<PaginationViewModel<RestaurantMenuItemDetailsVM>>.SuccessResult(
                    data,
                    "Meals retrieved successfully"
                );
            }
            catch (Exception ex)
            {
                return ServiceResult<PaginationViewModel<RestaurantMenuItemDetailsVM>>.FailureResult(
                    $"Error occurred while retrieving meals: {ex.Message}"
                );
            }
        }
        public ServiceResult CreateMeal(AddRestaurantMenuItemVM meal)
        {
            try
            {
                var restaurant = restaurantRepository.GetList(r => r.OwnerId == meal.RestaurantOwnerId).FirstOrDefault();
                if(restaurant == null)
                    return ServiceResult.FailureResult("Restaurnt not found");

                meal.RestaurantId = restaurant.Id;
                menuItemRepository.Add(meal.ToModel());
                return ServiceResult.SuccessResult("Meal added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);

            }
        }
        public async Task<ServiceResult> EditMeal(AddRestaurantMenuItemVM meal, int id)
        {
            try
            {
                var oldMeal = menuItemRepository.GetList(m => m.Id == id).FirstOrDefault();
                menuItemRepository.Update(meal.ToEditModel(oldMeal));

                return ServiceResult.SuccessResult("Meal Updated successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);
            }
        }
        public async Task<ServiceResult> DeleteMeal(int mealId)
        {
            try
            {
                var meal = menuItemRepository.GetList(m => m.Id == mealId).FirstOrDefault();
                if (meal != null)
                {
                    menuItemRepository.Delete(meal);
                    return ServiceResult.SuccessResult("Meal Deleted successfully.");

                }
                else
                {
                    return ServiceResult.FailureResult("Meal Not Found");

                }
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);

            }
        }
        public ServiceResult<List<RestaurantMenuItemDetailsVM>> GetMealsByRestaurant(int restaurantId)
        {
            try
            {
                var meals = menuItemRepository.GetMealsByRestaurantId(restaurantId);
                return ServiceResult<List<RestaurantMenuItemDetailsVM>>.SuccessResult(meals, "Meals loaded successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<List<RestaurantMenuItemDetailsVM>>.FailureResult($"Failed to load meals: {ex.Message}");
            }
        }

        public async Task<ServiceResult<RestaurantMenuItemDetailsVM>> GetMealById(int mealId)
        {
            try
            {
                var meal = menuItemRepository.GetMealById(mealId);
                if (meal == null)
                {
                    return ServiceResult<RestaurantMenuItemDetailsVM>.FailureResult("Meal not found.");
                }

                return ServiceResult<RestaurantMenuItemDetailsVM>.SuccessResult(meal.ToDetailsViewModel(), "Meal retrieved successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult<RestaurantMenuItemDetailsVM>.FailureResult($"Error retrieving meal: {ex.Message}");
            }
        }
    }
}
