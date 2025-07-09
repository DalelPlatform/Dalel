using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.WeddingPlaces.Enums;
using System.Security.Claims;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantMealController : ControllerBase
    {
        
        private RestaurantService restaurantService;

        public RestaurantMealController( RestaurantService restaurantService)
        {
            
            this.restaurantService = restaurantService;
        }

        [HttpGet("search")]
        public IActionResult SearchMeals(
           [FromQuery] string searchText = "",
           [FromQuery] float? minPrice = null,
           [FromQuery] float? maxPrice = null,
           [FromQuery] List<Models.Enums.AvaliabilityStatus>? avaliabilityStatus = null,
           [FromQuery] List<FoodCategory>? foodCategory = null,
           [FromQuery] List<SizeOfPiece>? sizeOfPiece = null,
           //[FromQuery] List<RestaurantType>? RestaurantType = null,
           [FromQuery] double? duration = null,
           [FromQuery] string sortBy = "Name",
           [FromQuery] bool descending = false,
           [FromQuery] int pageSize = 2,
           [FromQuery] int pageIndex = 1)
        {
            var result = restaurantService.SearchMeals(
                    searchText,
                    minPrice,
                    maxPrice,
                    avaliabilityStatus,
                    foodCategory,
                    sizeOfPiece,
                    //RestaurantType,
                    duration,
                    sortBy,
                    descending,
                    pageSize,
                    pageIndex);

            if (!result.Success)
                return new JsonResult(result);

            return new JsonResult(result);
        }

        [HttpPost("AddMeal")]
        [Authorize(Roles = "RestaurantOwner")]
        public IActionResult AddMeal([FromForm] AddRestaurantMenuItemVM meal)
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
        [HttpGet("GetMeal/{id}")]
        public IActionResult GetMealByID(int id)
        {
            var result =  restaurantService.GetMealById(id);
            if (!result.Success)
                return new JsonResult(result.Message);

            return new JsonResult(result);
        }
        [HttpGet("GetMealsByRestaurantId/{id}")]
        public IActionResult GetMealsByRestaurantId(int id)
        {
            var Meals = restaurantService.GetMealsByRestaurant(id);
            if (!Meals.Success)
                return new JsonResult(Meals.Message);

            return new JsonResult(Meals);

        }

        [HttpGet("GetAllMeals")]
        public IActionResult GetAllMeals()
        {
            var Meals = restaurantService.GetAllMeals();
            if (!Meals.Success)
                return new JsonResult(Meals.Message);

            return new JsonResult(Meals);

        }

        [HttpGet("GetMealCategory")]
        public IActionResult getMealType([FromQuery]FoodCategory category )
        {
            var Meals = restaurantService.GetMealType(category);
            if (!Meals.Success)
                return new JsonResult(Meals.Message);

            return new JsonResult(Meals);

        }


    }
}
