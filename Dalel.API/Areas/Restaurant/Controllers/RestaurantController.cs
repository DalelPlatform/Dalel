using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using System.Security.Claims;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private RestaurantService restaurantService;
        public RestaurantController(RestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }
        [HttpGet("search")]
        public IActionResult SearchRestaurants(
           [FromQuery] string searchText = "",
           [FromQuery] string city = null,
           [FromQuery] string region = null,
           [FromQuery] string street = null,
           [FromQuery] string address = null,
           [FromQuery] int NumberOfRooms = 0,
           [FromQuery] VerificationStatus? verificationStatus = null,
           [FromQuery] string sortBy = "Name",
           [FromQuery] bool descending = false,
           [FromQuery] int pageSize = 5,
           [FromQuery] int pageIndex = 1)
        {
            var result = restaurantService.Search(
                    searchText, city, region, street, address, NumberOfRooms, verificationStatus,
                    sortBy, descending, pageSize, pageIndex);
            if (!result.Success)
                return new JsonResult(result);
            return new JsonResult(result);
        }
        [HttpPost]
        [Authorize(Roles = "RestaurantOwner")]
        public async Task<IActionResult> AddRestaurant([FromBody] AddRestaurantVM model)
        {
            model.OwnerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await restaurantService.CreateRestaurant(model);
            if (ModelState.IsValid)
            {
                if (!result.Success)
                    return new JsonResult(result);
            }
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
       [Authorize(Roles = "RestaurantOwner")]
        public async Task<IActionResult> EditRestaurant([FromBody] AddRestaurantVM model,int id)
        {
            var result = await restaurantService.EditRestaurant(model, id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var result = await restaurantService.DeleteRestaurant(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var result = await restaurantService.GetAll();
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var result = await restaurantService.GetRestaurantById(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("getByVerificationStatus/{status}")]
        public async Task<IActionResult> GetRestaurantsByVerificationStatus(VerificationStatus status)
        {
            var result = await restaurantService.GetRestaurantsByVerificationStatus(status);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

    }
}
