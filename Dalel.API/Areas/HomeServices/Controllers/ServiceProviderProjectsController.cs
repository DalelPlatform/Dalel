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

        [HttpPost("CreateProject")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult CreateProject([FromForm] AddServiceProviderProjectVM model, [FromForm(Name = "imageFiles")] List<IFormFile> imageFiles)
        {
            var result = _homeServiceService.CreateProject(model, imageFiles);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
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
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var result = _homeServiceService.GetProjectById(id);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult UpdateProject(int projectId, [FromForm] AddServiceProviderProjectVM model, [FromForm(Name = "imageFiles")] List<IFormFile> imageFiles = null)
        {
            var result = _homeServiceService.UpdateProject(projectId, model, imageFiles);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Message = result.Message });
        }

        [HttpPut("image/{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult UpdateProjectImage(int projectId, [FromForm(Name = "imageFiles")] List<IFormFile> imageFiles)
        {
            var result = _homeServiceService.UpdateProjectImage(projectId, imageFiles);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Message = result.Message });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int projectId)
        {
            var result = _homeServiceService.DeleteProject(projectId);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Message = result.Message });
        }
    }
}