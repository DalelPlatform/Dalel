using Dalel.Services;
using Dalel.ViewModels;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Utilities;

namespace Dalel.API.Controllers.HomeChef
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



        

        [HttpPost("AddMeal")]
        public IActionResult AddMeal(AddHomeChefMealVM mealVm)
        {
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


        [HttpPost("UpdateMeal")]

        public IActionResult UpdateMeal (AddHomeChefMealVM mealVM)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdateMeal(mealVM);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }


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
