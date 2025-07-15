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
        public IActionResult CreateProject([FromForm] AddServiceProviderProjectVM model)
        {
            model.ServiceProviderId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.CreateProject(model);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Message = result.Message });
        }

        [HttpGet("provider")]
        public IActionResult GetProjectsByProvider(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1, [FromQuery] string providerId = "")
        {
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

        [HttpPut("UpdateProject")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult UpdateProject(int projectId, [FromForm] AddServiceProviderProjectVM model)
        {
            var result = _homeServiceService.UpdateProject(projectId, model);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Message = result.Message });
        }


        [HttpDelete("DeleteProject")]
        public IActionResult DeleteProject(int projectId)
        {
            var result = _homeServiceService.DeleteProject(projectId);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Message = result.Message });
        }
    }
}