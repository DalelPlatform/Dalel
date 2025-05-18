using System.Security.Claims;
using Dalel.Services;
using Dalel.ViewModels;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Utilities;

namespace Dalel.API.Areas.HomeChef.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeChefMealController : ControllerBase
    {
        private readonly HomeChefService _homeChefService;

        public HomeChefMealController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }


        [HttpGet("search")]
        public IActionResult Search(
            string searchText = "",
            bool? AvailabilityStatus = true, // default = true
            string? owner = "",
            FoodCategory? foodCategory = null, // now filtering by enum
            decimal? Price = null,
            int pageSize = 10,
            int pageIndex = 1,
            string OrderBy = "Id",
            bool IsAscending = false)
        {
            var result = _homeChefService.Search(
                searchText,
                AvailabilityStatus,
                owner,
                foodCategory,
                Price,
                pageSize,
                pageIndex,
                OrderBy,
                IsAscending
            );

            if (!result.Success)
                return new JsonResult(result);

            return new JsonResult(result);
        }

        [Authorize(Roles ="HomeChef")]
        [HttpPost("AddMeal")]
        public IActionResult AddMeal(AddHomeChefMealVM mealVm)
        {

            mealVm.HomeChefId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.AddMeal(mealVm);

            if (result.Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result.Message);

        }

        [Authorize(Roles = "HomeChef")]
        [HttpPost("UpdateMeal/{id}")]

        public IActionResult UpdateMeal (int id ,AddHomeChefMealVM mealVM)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }
            var result = _homeChefService.UpdateMeal(id,mealVM);
            if (result.Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result);
        }

        [Authorize(Roles = "HomeChef")]
        [HttpPost("DeleteMealById")]

        public IActionResult DeleteMeal (int id)
        {
            var result = _homeChefService.DeleteMeal(id);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }


        [HttpPost("DeleteMealByDishName")]

        public IActionResult DeleteMeal(string dishname)
        {
            var result = _homeChefService.DeleteMeal(dishname);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }




        [HttpGet("GetMealById")]

        public ActionResult GetMealById(int id)
        {
            var result = _homeChefService.GetMealById(id);

            if(result.Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result);
           
        }



        [HttpGet("GetMealsByChefId")]
        public ActionResult GetMealsByChefId(string chefId)
        {
            var result = _homeChefService.GetMealsByChefId(chefId);

            if (result[0].Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result);
            
        }



        [HttpGet("GetAllMeal")]

        public IActionResult GetAllMeals()
        {
            var result = _homeChefService.GetAllMeals();

            if (result[0].Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result);
           
        }



        [HttpGet("GetMealsByCategory")]

        public IActionResult GetMealsByCategory(FoodCategory category)
        {
            var result = _homeChefService.GetMealsByCategory(category);

            if (result[0].Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result);
            
        }



        [HttpGet("GetAvailableMeals")]
        public IActionResult GetAvailableMeals(bool status)
        {
            var result = _homeChefService.GetAvailableMeals(status);

            if (result[0].Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result);
           
        }


       

    }
}
