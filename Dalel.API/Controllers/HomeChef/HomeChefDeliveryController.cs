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
    public class HomeChefDeliveryController : ControllerBase
    {
        private readonly HomeChefService _homeChefService;

        public HomeChefDeliveryController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }



        [Authorize(Roles = "Client,Admin,HomeChef")]


        [HttpPost("AddOrder")]
        public IActionResult AddDeliveryOrder(AddHomeChefDeliveryVM deliveryVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.AddDeliveryOrder(deliveryVm);

            if (result.Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result.Message);

        }

        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("UpdateOrder")]

        public IActionResult UpdateDeliveryOrder(AddHomeChefDeliveryVM deliveryVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdateDeliveryOrder(deliveryVm);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }




        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("DeleteMealById")]

        public IActionResult DeleteDeliveryOrder(int id)
        {
            var result = _homeChefService.DeleteDeliveryOrder(id);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }


    }
}
