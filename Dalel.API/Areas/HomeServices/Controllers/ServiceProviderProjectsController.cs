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
    public class ServiceProviderProjectController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ServiceProviderProjectController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult CreateProject([FromForm] AddServiceProviderProjectVM model)
        {
            var result = _homeServiceService.CreateProject(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("provider")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult GetProjectsByProvider(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var providerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetProjectsByProvider(providerId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var result = _homeServiceService.GetProjectById(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult UpdateProject(int id, [FromForm] AddServiceProviderProjectVM model)
        {
            var result = _homeServiceService.UpdateProject(id, model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("image/{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult UpdateProjectImage(int id, [FromForm] string newImagePath)
        {
            var result = _homeServiceService.UpdateProjectImage(id, newImagePath);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult DeleteProject(int id)
        {
            var result = _homeServiceService.DeleteProject(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}