using Microsoft.AspNetCore.Mvc;
using Dalel.Services.Reviews;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyReview;
using Dalel.ViewModels.Restaurant;
using Utilities;

namespace Dalel.API.Areas
{
    [Area("Review")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _service;

        public ReviewController(ReviewService service)
        {
            _service = service;
        }

        #region Agency Reviews
        [HttpPost("agency")]
        public IActionResult CreateAgency([FromBody] AddAgencyReview vm)
        {
            var result = _service.CreateAgencyReview(vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("agency/{id}")]
        public IActionResult EditAgency(int id, [FromBody] AddAgencyReview vm)
        {
            var result = _service.EditAgencyReview(id, vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("agency/{id}")]
        public IActionResult DeleteAgency(int id)
        {
            var result = _service.DeleteAgencyReview(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        #endregion

        #region Vehicle Reviews
        [HttpPost("vehicle")]
        public IActionResult CreateVehicle([FromBody] AddReviewVehicle vm)
        {
            var result = _service.CreateVehicleReview(vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("vehicle/{id}")]
        public IActionResult EditVehicle(int id, [FromBody] AddReviewVehicle vm)
        {
            var result = _service.EditVehicleReview(id, vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("vehicle/{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var result = _service.DeleteVehicleReview(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        #endregion

        #region HomeChef Order Reviews
        [HttpPost("homechef")]
        public IActionResult CreateHomeChef([FromBody] AddReviewHomeChefOrderVM vm)
        {
            var result = _service.CreateHomeChefReview(vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("homechef/{id}")]
        public IActionResult EditHomeChef(int id, [FromBody] AddReviewHomeChefOrderVM vm)
        {
            var result = _service.EditHomeChefReview(id, vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("homechef/{id}")]
        public IActionResult DeleteHomeChef(int id)
        {
            var result = _service.DeleteHomeChefReview(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        #endregion

        #region ServiceProvider Reviews
        [HttpPost("serviceprovider")]
        public IActionResult CreateServiceProvider([FromBody] AddServiceProviderReviewVM vm)
        {
            var result = _service.CreateServiceProviderReview(vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("serviceprovider/{id}")]
        public IActionResult EditServiceProvider(int id, [FromBody] AddServiceProviderReviewVM vm)
        {
            var result = _service.EditServiceProviderReview(id, vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("serviceprovider/{id}")]
        public IActionResult DeleteServiceProvider(int id)
        {
            var result = _service.DeleteServiceProviderReview(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        #endregion

        #region Hotel Room Reviews
        [HttpPost("hotel")]
        public IActionResult CreateHotel([FromBody] ReviewCreation vm)
        {
            var result = _service.CreateHotelReview(vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("hotel/{id}")]
        public IActionResult EditHotel(int id, [FromBody] ReviewCreation vm)
        {
            var result = _service.EditHotelReview(id, vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("hotel/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            var result = _service.DeleteHotelReview(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        #endregion

        #region Property Reviews
        [HttpPost("property")]
        public IActionResult CreateProperty([FromBody] AddReviewPropertiesVM vm)
        {
            var result = _service.CreatePropertyReview(vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("property/{id}")]
        public IActionResult EditProperty(int id, [FromBody] AddReviewPropertiesVM vm)
        {
            var result = _service.EditPropertyReview(id, vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("property/{id}")]
        public IActionResult DeleteProperty(int id)
        {
            var result = _service.DeletePropertyReview(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        #endregion

        #region Restaurant Order Reviews
        [HttpPost("restaurant")]
        public IActionResult CreateRestaurant([FromBody] AddReviewRestaurantOrderVM vm)
        {
            var result = _service.CreateRestaurantReview(vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("restaurant/{id}")]
        public IActionResult EditRestaurant(int id, [FromBody] AddReviewRestaurantOrderVM vm)
        {
            var result = _service.EditRestaurantReview(id, vm);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("restaurant/{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var result = _service.DeleteRestaurantReview(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        #endregion
    }
}
