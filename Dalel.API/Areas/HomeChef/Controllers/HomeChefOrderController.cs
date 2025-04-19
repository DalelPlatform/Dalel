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
    public class HomeChefOrderController : ControllerBase
    {
        private readonly HomeChefService _homeChefService;

        public HomeChefOrderController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }



        [Authorize(Roles = "Client,Admin,HomeChef")]


        [HttpPost("AddOrder")]
        public IActionResult AddOrder(AddHomeChefOrderVM orderVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.AddOrder(orderVm);

            if (result.Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result.Message);

        }

        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("UpdateOrder/{id}")]

        public IActionResult UpdateOrder(int id ,AddHomeChefOrderVM orderVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdateOrder(id,orderVm);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }

        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("DeleteOrderById")]

        public IActionResult DeleteOrder(int id)
        {
            var result = _homeChefService.DeleteOrder(id);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }


    



        //[HttpGet("GetMealById")]

        //public ActionResult GetMealById(int id)
        //{
        //    var result = _homeChefService.GetMealById(id);

        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //    //return NotFound(result);
        //}



        //[HttpGet("GetMealsByChefId")]
        //public ActionResult GetMealsByChefId(string chefId)
        //{
        //    var result = _homeChefService.GetMealsByChefId(chefId);

        //    if (result[0].Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //    //return NotFound(result);
        //}



        //[HttpGet("GetAllMeal")]

        //public IActionResult GetAllMeals()
        //{
        //    var result = _homeChefService.GetAllMeals();

        //    if (result[0].Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //    //return NotFound(result);
        //}



        //[HttpGet("GetMealsByCategory")]

        //public IActionResult GetMealsByCategory(FoodCategory category)
        //{
        //    var result = _homeChefService.GetMealsByCategory(category);

        //    if (result[0].Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //    //return NotFound(result);
        //}



        //[HttpGet("GetAvailableMeals")]
        //public IActionResult GetAvailableMeals(bool status)
        //{
        //    var result = _homeChefService.GetAvailableMeals(status);

        //    if (result[0].Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //    //return NotFound(result);
        //}


        //[HttpGet("GetAvailableMeals")]
        //public IActionResult SearchMeals(string keyword)
        //{
        //    var result = _homeChefService.SearchMeals(keyword);

        //    if (result[0].Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //    //return NotFound(result);
        //}

    }
}
