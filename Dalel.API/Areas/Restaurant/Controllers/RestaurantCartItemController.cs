using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dalel.API.Areas.Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantCartItemController : ControllerBase
    {

        private RestaurantService restaurantService;
        public RestaurantCartItemController(RestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpPost("AddToCart")]
        //[Authorize(Roles = "Client")]
        public IActionResult AddToCart([FromBody] AddRestaurantCartItemVM item)
        {
            item.ClientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (item.ClientId == null)
            {
                return new JsonResult("UnAuthorized.");
            }
            var result = restaurantService.AddCartItem(item);
            if (ModelState.IsValid)
            {
                if (!result.Success)
                    return new JsonResult(result);

            }
            return new JsonResult(result);
        }


        [HttpGet("GetCartItems")]
        //[Authorize(Roles = "Client")]
        public IActionResult GetCartItems()
        {
            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(clientId))
            {
                return new JsonResult("UnAuthorized.");
            }
            var result = restaurantService.GetCartItemsByClientId(clientId);
            if (!result.Success)
                return new JsonResult(result);
            return new JsonResult(result);
        }


        [HttpPut("EditCartItem/{id}")]
        //[Authorize(Roles = "Client")]
        public IActionResult EditCartItem([FromBody] AddRestaurantCartItemVM edit, int id)
        {
            edit.ClientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = restaurantService.UpdateCartItem(id, edit);
            if (ModelState.IsValid)
            {
                if (!result.Success)
                    return new JsonResult(result);
            }
            return new JsonResult(result);
        }


        [HttpDelete("DeleteCartItem/{id}")]
        //[Authorize(Roles = "Client")]

        public IActionResult DeleteCartItem(int id)
        {
            var result = restaurantService.DeleteCartItem(id);
            if (!result.Success)
                return new JsonResult(result);
            return new JsonResult(result);
        }

    }
}
