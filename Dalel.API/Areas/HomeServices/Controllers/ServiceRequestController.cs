using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Stripe;
using System.Security.Claims;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ServiceRequestController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Client")]
        public IActionResult CreateServiceRequest([FromForm] AddServiceRequestVM model)
        {
            model.ClientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(model.ClientId))
                return new JsonResult("User not authenticated") { StatusCode = 401 };

            var result = _homeServiceService.CreateServiceRequest(model);

            if (!result.Success)
                return new JsonResult(result.Message) { StatusCode = 400 };

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceRequestById(int id)
        {
            var result = _homeServiceService.GetServiceRequestById(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("client")]
        [Authorize(Roles = "Client")]
        public IActionResult GetRequestsByClient(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetRequestsByClient(clientId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }


        [HttpGet("ServiceRequestSearch")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult SearchServiceRequests(
            [FromQuery] string? Title = "",
            [FromQuery] string? Description = null,
            [FromQuery] string? Address = null,
            [FromQuery] int? CategoryId = null,
            [FromQuery] string sortBy = "Date",
            [FromQuery] bool descending = false,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageIndex = 1)
        {
            var result = _homeServiceService.SearchServiceRequest(Title, Description, Address,CategoryId, sortBy, descending, pageSize, pageIndex);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("status/{status}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetRequestsByStatus(
            RequestStatus status,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetRequestsByStatus(status, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public IActionResult UpdateServiceRequest(int id, [FromForm] AddServiceRequestVM model)
        {
            var result = _homeServiceService.UpdateServiceRequest(id, model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public IActionResult DeleteServiceRequest(int id)
        {
            var result = _homeServiceService.DeleteServiceRequest(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpGet("AcceptedRequest")]
        public IActionResult GetAcceptedRequests(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetAcceptedRequests(pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpGet("PendingRequest")]
        public IActionResult GetPendingRequests(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetPendingRequests(pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }


        [HttpGet("CompletedRequest")]
        public IActionResult GetCompletedRequests(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetCompletedRequests(pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }


        [HttpGet("RejectedRequest")]
        public IActionResult GetRejectedRequests(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetRejectedRequests(pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }


    }
}