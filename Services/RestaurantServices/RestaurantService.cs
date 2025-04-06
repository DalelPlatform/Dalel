using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.Repository;
using Models.HomeService;
using Models.Restaurant;
using Utilities;

namespace Dalel.Services
{
    public class RestaurantService 

    {
        public readonly RestaurantRepository _RestaurantRepo; 


        public RestaurantService(RestaurantRepository restaurantRepo)
        {
            _RestaurantRepo = restaurantRepo;
        }



        public async Task<ServiceResult> CreateRestaurant(Restaurant restaurant)
        {
            try
            {
                 _RestaurantRepo.Add(restaurant); // again, assuming async manager method
                return new ServiceResult
                {
                    Success = true,
                    Message = "Restaurant added successfully."
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

        public async Task<ServiceResult> EditRestaurant(Restaurant restaurant)
        {
            try
            {
                _RestaurantRepo.Update(restaurant); // again, assuming async manager method
                return new ServiceResult
                {
                    Success = true,
                    Message = "Restaurant updated successfully."
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
        public async Task<ServiceResult> DeleteMeal(int restaurantId)
        {
            try
            {
                var restaurant = _RestaurantRepo.GetList(r => r.Id == restaurantId).FirstOrDefault();
                if (restaurant != null)
                {
                    _RestaurantRepo.Delete(restaurant);
                    return new ServiceResult
                    {
                        Success = true,
                        Message = "Restaurant deleted successfully."
                    };
                }
                else
                {
                    return new ServiceResult
                    {
                        Success = false,
                        Message = "Restaurant not found."
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
