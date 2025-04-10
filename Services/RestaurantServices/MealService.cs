using Dalel.Repository;
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
        public async Task<ServiceResult> AddMeal(RestaurantMenuItem meal)
        {
            try
            {
                menuItemRepository.Add(meal);
                return new ServiceResult
                {
                    Success = true,
                    Message = "Meal added successfully."
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<ServiceResult> EditMeal(RestaurantMenuItem meal)
        {
            try
            {
                menuItemRepository.Update(meal);
                return new ServiceResult
                {
                    Success = true,
                    Message = "Meal updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = ex.Message
                };
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
                    return new ServiceResult
                    {
                        Success = true,
                        Message = "Meal deleted successfully."
                    };
                }
                else
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Meal not found."
                    };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
