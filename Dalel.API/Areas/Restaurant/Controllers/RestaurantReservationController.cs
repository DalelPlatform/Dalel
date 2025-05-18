using System.Security.Claims;
using Dalel.Services;
using Dalel.ViewModels.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas.Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantReservationController : ControllerBase
    {
        private RestaurantService restaurantService;

        public RestaurantReservationController(RestaurantService restaurantService)
        {

            this.restaurantService = restaurantService;
        }



        [Authorize(Roles = "Client")]
        [HttpPost("addReservation")]

        public IActionResult AddReservation(AddRestaurantReservationVM vm)
        {

            var ClientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(ClientId))
            {
                return BadRequest("ClientId is required.");
            }
            vm.ClientId = ClientId;
            var result = restaurantService.CreateRestaurantReservation(vm);
            if (!result.Success)
                return new JsonResult(result);
            return new JsonResult(result);
        }


        [Authorize(Roles = "Client,Admin,RestaurantOwner")]
        [HttpGet("EditReservation")]
        public IActionResult EditReservation(int id, AddRestaurantReservationVM vm)
        {
            var result = restaurantService.EditRestaurantReservation(vm, id);
            if (!result.Success)
                return new JsonResult(result);
            return new JsonResult(result);
        }


        [Authorize(Roles = "Client,Admin,RestaurantOwner")]
        [HttpDelete("deleteReservation")]
        public IActionResult DeleteReservation(int id)
        {
            var result = restaurantService.DeleteReserve(id);
            if (!result.Success)
                return new JsonResult(result);
            return new JsonResult(result);
        }

    }
}
