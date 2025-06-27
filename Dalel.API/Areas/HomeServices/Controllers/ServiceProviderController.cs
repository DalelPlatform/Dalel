using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Dalel.ViewModels.HomeServices.ServiceProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using System.Security.Claims;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceProviderController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ServiceProviderController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpGet("check-profile")]
        public IActionResult CheckServiceProviderProfile()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.CheckProfileCompleteness(userId);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpPut("create")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult CreateServiceProvider([FromForm] AddServiceProviderVM model)
        {
            model.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.CreateServiceProvider(model);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpGet("search")]
        public IActionResult SearchServiceProviders(
            [FromQuery] string searchText = "",
            [FromQuery] int? categoryId = null,
            [FromQuery] string address = null,
            [FromQuery] VerificationStatus? verificationStatus = null,
            [FromQuery] string sortBy = "Name",
            [FromQuery] bool descending = false,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageIndex = 1)
        {
            var result = _homeServiceService.SearchServiceProviders(searchText, categoryId, address, verificationStatus, sortBy, descending, pageSize, pageIndex);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpGet("profile")]
        public IActionResult GetServiceProviderById()
        {

            string id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetServiceProviderById(id);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpGet("ProfileById")]//عشان اعرض بيانات اليوزر صاحب البروبوزال
        public IActionResult GetServiceProviderDataById(string id)
        {
            var result = _homeServiceService.GetServiceProviderById(id);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetProvidersByCategory(
            int categoryId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetProvidersByCategory(categoryId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpGet("top-rated/{count}")]
        public IActionResult GetTopRatedProviders(int count)
        {
            var result = _homeServiceService.GetTopRatedProviders(count);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpGet("exists/{id}")]
        public IActionResult ProviderExists(string id)
        {
            var result = _homeServiceService.ProviderExists(id);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ServiceProvider,Admin")]
        public IActionResult UpdateServiceProvider(int id, [FromForm] AddServiceProviderVM model, [FromQuery] VerificationStatus? verificationStatus = null)
        {
            var result = _homeServiceService.UpdateServiceProvider(id, model);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Data = result.Data, Message = result.Message });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteServiceProvider(int id)
        {
            var result = _homeServiceService.DeleteServiceProvider(id);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Message = result.Message });
        }
    }
}