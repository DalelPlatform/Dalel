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
    public class ServiceProviderProposalController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ServiceProviderProposalController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult CreateProposal([FromForm] AddServiceProviderProposalVM model)
        {
            model.ServiceProviderId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.CreateProposal(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("request/{requestId}")]
        public IActionResult GetProposalsByRequest(
            int requestId,
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var result = _homeServiceService.GetProposalsByRequest(requestId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("provider")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult GetProposalsByProvider(
            [FromQuery] int pageSize = 5,
            [FromQuery] int pageNumber = 1)
        {
            var providerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetProposalsByProvider(providerId, pageSize, pageNumber);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetProposalById(int id)
        {
            var result = _homeServiceService.GetProposalById(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult UpdateProposal(int id, [FromForm] AddServiceProviderProposalVM model)
        {
            var result = _homeServiceService.UpdateProposal(id, model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("accept/{id}")]
        [Authorize(Roles = "Client")]
        public IActionResult AcceptProposal(int id)
        {
            var result = _homeServiceService.AcceptProposal(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("reject/{id}")]
        [Authorize(Roles = "Client")]
        public IActionResult RejectProposal(int id)
        {
            var result = _homeServiceService.RejectProposal(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPut("cancel/{serviceRequestId}")]
        [Authorize(Roles = "Client")]
        public IActionResult CancelProposals(int serviceRequestId)
        {
            var result = _homeServiceService.CancelProposals(serviceRequestId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ServiceProvider")]
        public IActionResult DeleteProposal(int id)
        {
            var result = _homeServiceService.DeleteProposal(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}