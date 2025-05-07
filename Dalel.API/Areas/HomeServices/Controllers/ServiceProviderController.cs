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

        [HttpPost("create")]
        //[Authorize(Roles = "ServiceProvider")]
        public IActionResult CreateServiceProvider([FromForm] AddServiceProviderVM model)
        {
            var result = _homeServiceService.CreateServiceProvider(model);
            if (!result.Success)
                return new JsonResult(new { Success = false, Message = result.Message });
            return new JsonResult(new { Success = true, Message = result.Message, Data = result.Data });
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
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetServiceProviderById(string id)
        {
            var result = _homeServiceService.GetServiceProviderById(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetProvidersByCategory(
            int categoryId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetProvidersByCategory(categoryId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("top-rated/{count}")]
        public IActionResult GetTopRatedProviders(int count)
        {
            var result = _homeServiceService.GetTopRatedProviders(count);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("exists/{id}")]
        public IActionResult ProviderExists(string id)
        {
            var result = _homeServiceService.ProviderExists(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "ServiceProvider,Admin")]
        public IActionResult UpdateServiceProvider(int id, [FromForm] AddServiceProviderVM model, VerificationStatus verificationStatus)
        {
            var result = _homeServiceService.UpdateServiceProvider(id, model, verificationStatus);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult DeleteServiceProvider(int id)
        {
            var result = _homeServiceService.DeleteServiceProvider(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}