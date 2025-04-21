using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.WeddingPlaces.Enums;
using System.Security.Claims;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        
        private RestaurantService restaurantService;

        public MealController( RestaurantService restaurantService)
        {
            
            this.restaurantService = restaurantService;
        }

        [HttpGet("search")]
        public IActionResult SearchMeals(
           [FromQuery] string search = "",
           [FromQuery] float? minPrice = null,
           [FromQuery] float? maxPrice = null,
           [FromQuery] Models.Enums.AvaliabilityStatus? avaliabilityStatus = null,
           [FromQuery] FoodCategory? foodCategory = null,
           [FromQuery] SizeOfPiece? sizeOfPiece = null,
           [FromQuery] double? duration = null,
           [FromQuery] string sortBy = "Name",
           [FromQuery] bool descending = false,
           [FromQuery] int pageSize = 5,
           [FromQuery] int pageIndex = 1)
        {
            var result = restaurantService.SearchMeals(
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

            var result = restaurantService.CreateMeal(meal);
            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "RestaurantOwner")]
        public IActionResult UpdateMeal([FromBody] AddRestaurantMenuItemVM meal, int id)
        {
            var result = restaurantService.EditMeal(meal,id);

            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "RestaurantOwner")]
        public IActionResult DeleteMeal(int id)
        {
            var result =  restaurantService.DeleteMeal(id);

            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetMealByID(int id)
        {
            var result =  restaurantService.GetMealById(id);
            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }
    }
}
