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
    public class HomeChefOrderMealController : ControllerBase
    {
        private readonly HomeChefService _homeChefService;

        public HomeChefOrderMealController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }



        //[Authorize(Roles = "Client,Admin,HomeChef")]


        [HttpPost("AddOrderMeal")]
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


        [HttpGet("search")]
        public IActionResult Search(
          string searchText = "",
          string? customerId = "",
          int pageSize = 10,
          int pageIndex = 1,
          string orderBy = "Id",
          bool IsAscending = false)
        {
            var result = _homeChefService.Search(
                searchText,
                customerId,
                pageSize,
                pageIndex,
                orderBy,
                IsAscending
            );

            if (!result.Success)
                return new JsonResult(result);

            return new JsonResult(result);
        }


        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("UpdateOrderMeal/{id}")]

        public IActionResult UpdateOrderMeal(int id ,AddHomeChefOrderMealVM orderMealVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdateOrderMeal(id,orderMealVm);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }



        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("DeleteOrderMealById")]

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

