using Dalel.Services;
using Dalel.ViewModels;
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

        public MealController(MealService mealService)
        {
            this.mealService = mealService;
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
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeal([FromBody] AddRestaurantMenuItemVM meal)
        {
            meal.RestaurantOwnerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await mealService.CreateMeal(meal);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeal([FromBody] AddRestaurantMenuItemVM meal)
        {
            var result = await mealService.EditMeal(meal.ToModel());
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            var result = await mealService.DeleteMeal(id);
            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealByID(int id)
        {
            var result = await mealService.GetMealById(id);
            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result);
        }
    }
}
