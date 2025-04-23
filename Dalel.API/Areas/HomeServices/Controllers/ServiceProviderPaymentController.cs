using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProviderPaymentController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ServiceProviderPaymentController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Client")]
        public IActionResult CreatePayment([FromForm] AddServiceProviderPayment model)
        {
            var result = _homeServiceService.CreatePayment(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("request/{requestId}")]
        public IActionResult GetPaymentByRequest(int requestId)
        {
            var result = _homeServiceService.GetPaymentByRequest(requestId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("provider/{providerId}")]
        public IActionResult GetPaymentsByProvider(
            string providerId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetPaymentsByProvider(providerId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public IActionResult UpdatePayment(int id, [FromForm] AddServiceProviderPayment model)
        {
            var result = _homeServiceService.UpdatePayment(id, model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("status/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdatePaymentStatus(int id, [FromBody] PaymentStatus status)
        {
            var result = _homeServiceService.UpdatePaymentStatus(id, status);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePayment(int id)
        {
            var result = _homeServiceService.DeletePayment(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}