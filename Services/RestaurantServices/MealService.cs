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
        public MealService(RestaurantMenuItemRepository menuItemRepository)
        {
            this.menuItemRepository = menuItemRepository;
        }

        public ServiceResult<PaginationViewModel<RestaurantMenuItemDetailsVM>> SearchMeals(
            string searchText = "",
            FoodCategory? category = null,
            AvaliabilityStatus status = AvaliabilityStatus.Available,
            float? minPrice = null,
            float? maxPrice = null,
            int pageSize = 4,
            int pageIndex = 1,
            string sortBy = "Name",
            bool descending = false)
        {
            try
            {
                var data = menuItemRepository.SearchMenuItem(
                    searchText,
                    category,
                    status,
                    minPrice,
                    maxPrice,
                    pageSize,
                    pageIndex,
                    sortBy,
                    descending
                );

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
        public async Task<ServiceResult> CreateMeal(RestaurantMenuItem meal)
        {
            try
            {
                menuItemRepository.Add(meal);
                return ServiceResult.SuccessResult("Meal added successfully.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult(ex.Message);

            }
        }
        public async Task<ServiceResult> EditMeal(RestaurantMenuItem meal)
        {
            try
            {
                menuItemRepository.Update(meal);

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
