using Dalel.Services;
using Dalel.ViewModels;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Utilities;

namespace Dalel.API.Controllers.HomeChef
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeChefOrderMealController : ControllerBase
    {
        private readonly HomeChefService _homeChefService;

        public HomeChefOrderMealController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }



        //[Authorize(Roles = "Client,Admin,HomeChef")]


        [HttpPost("AddOrder")]
        public IActionResult AddOrderMeal(AddHomeChefOrderMealVM orderMealVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.AddOrderMeal(orderMealVm);

            if (result.Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result.Message);

        }




        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("UpdateOrder")]

        public IActionResult UpdateOrderMeal(AddHomeChefOrderMealVM orderMealVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdateOrderMeal(orderMealVm);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }



        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("DeleteMealById")]

        public IActionResult DeleteOrderMeal(int id)
        {
            var result = _homeChefService.DeleteOrderMeal(id);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }

    }

}

