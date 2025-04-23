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
    public class ServiceQuariesController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ServiceQuariesController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Client")]
        public IActionResult CreateServiceQuery([FromForm] AddServiceQuariesVM model)
        {
            var result = _homeServiceService.CreateServiceQuery(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetQueriesByCategory(
            int categoryId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetQueriesByCategory(categoryId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("client")]
        [Authorize(Roles = "Client")]
        public IActionResult GetQueriesByClient(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetQueriesByClient(clientId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("provider")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult GetQueriesByProvider(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var providerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetQueriesByProvider(providerId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("answer/{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult AnswerQuery(int id, [FromBody] string answer)
        {
            var result = _homeServiceService.AnswerQuery(id, answer);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetQueryById(int id)
        {
            var result = _homeServiceService.GetQueryById(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Client")]
        public IActionResult UpdateServiceQuery(int id, [FromForm] AddServiceQuariesVM model)
        {
            var result = _homeServiceService.UpdateServiceQuery(id, model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public IActionResult DeleteServiceQuery(int id)
        {
            var result = _homeServiceService.DeleteServiceQuery(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}