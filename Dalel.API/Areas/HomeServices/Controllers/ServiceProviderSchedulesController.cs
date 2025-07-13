using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProviderScheduleController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ServiceProviderScheduleController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpGet("provider")]
        public IActionResult GetSchedulesByProvider([FromQuery] string providerId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetSchedulesByProvider(providerId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("availability/{providerId}")]
        public IActionResult IsProviderAvailable(
            string providerId,
            [FromQuery] DateTime date,
            [FromQuery] string time)
        {
            var parsedTime = TimeOnly.Parse(time);
            var result = _homeServiceService.IsProviderAvailable(providerId, date, parsedTime);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
        [HttpPost("add")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult AddProviderSchedule(AddServiceProviderScheduleVM model)
        {
            model.ServiceProviderId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.AddProviderSchedule(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("update")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult UpdateProviderSchedule([FromBody] AddServiceProviderScheduleVM model)
        {
            model.ServiceProviderId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.UpdateProviderSchedule(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("delete")]
        //[Authorize(Roles = "ServiceProvider")]
        public IActionResult DeleteProviderSchedule(
            [FromQuery] string providerId,
            [FromQuery] DateTime date)
        {
            var result = _homeServiceService.DeleteProviderSchedule(providerId, date);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}