using System.Security.Claims;
using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.Restaurant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas.Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantOrderController : ControllerBase
    {
        private RestaurantService restaurantService;

        public RestaurantOrderController(RestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public IActionResult AddOrder([FromBody] AddRestaurantOrderVM order)
        {
           

            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(clientId))
                return new JsonResult("ClientId cannot be null or empty.");

            //var restaurantId = restaurantService.GetRestaurantById()

            // Assign the current user's ID to the order's ClientId  

            order.ClientId = clientId;

            var result = restaurantService.CreateOrder(order);

            if (!result.Success)
                return new JsonResult(result);

            return new JsonResult(result);
        }
    }
}
