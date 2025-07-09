using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.HomeService;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProviderReviewController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ServiceProviderReviewController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpPost("create")]
        //[Authorize(Roles = "Client")]
        public IActionResult CreateReview([FromForm] AddServiceProviderReviewVM model)
        {
            var result = _homeServiceService.CreateReview(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("request/{requestId}")]
        public IActionResult GetReviewByRequest(int requestId)
        {
            var result = _homeServiceService.GetReviewByRequest(requestId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("provider/{providerId}")]
        public IActionResult GetReviewsByProvider(
            string providerId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetReviewsByProvider(providerId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "Client")]
        public IActionResult UpdateReview(int id, [FromForm] AddServiceProviderReviewVM model)
        {
            var result = _homeServiceService.UpdateReview(id, model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Client")]
        public IActionResult DeleteReview(int id)
        {
            var result = _homeServiceService.DeleteReview(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}