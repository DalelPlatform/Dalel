using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using System.Security.Claims;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private MealService mealService;
        private RestaurantService restaurantService;

        public MealController(MealService mealService,RestaurantService restaurantService)
        {
            this.mealService = mealService;
            this.restaurantService = restaurantService;
        }

        [HttpGet("search")]
        public IActionResult SearchMeals(
               [FromQuery] string searchText = "",
               [FromQuery] FoodCategory? category = null,
               [FromQuery] AvaliabilityStatus status = AvaliabilityStatus.Available,
               [FromQuery] float? minPrice = null,
               [FromQuery] float? maxPrice = null,
               [FromQuery] int pageSize = 4,
               [FromQuery] int pageIndex = 1,
               [FromQuery] string sortBy = "Name",
               [FromQuery] bool descending = false)
        {
            var result = mealService.SearchMeals(
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

            if (!result.Success)
                return new JsonResult(result);

            return new JsonResult(result);
        }

        [HttpPost]
        [Authorize(Roles = "RestaurantOwner")]
        public IActionResult AddMeal([FromBody] AddRestaurantMenuItemVM meal)
        {
            meal.RestaurantOwnerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var Restaurant = restaurantService.GetRestaurantByOwnerId(meal.RestaurantOwnerId);
            meal.RestaurantId = Restaurant.Data.Id;

            var result =  mealService.CreateMeal(meal);
            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }

        [HttpPut]
        [Authorize(Roles = "RestaurantOwner")]
        public async Task<IActionResult> UpdateMeal([FromBody] AddRestaurantMenuItemVM meal)
        {
            var result = await mealService.EditMeal(meal.ToModel());
            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "RestaurantOwner")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var result = await mealService.DeleteMeal(id);
            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealByID(int id)
        {
            var result = await mealService.GetMealById(id);
            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }
    }
}
