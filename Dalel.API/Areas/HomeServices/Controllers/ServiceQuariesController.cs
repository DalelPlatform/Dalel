using Dalel.API.Hubs;
using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Models.HomeService;
using System.Security.Claims;

namespace Dalel.API.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceQuariesController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;
        private readonly IHubContext<ChatHub> _hub;


        public ServiceQuariesController(HomeServiceService homeServiceService,IHubContext<ChatHub> hub)
        {
            _homeServiceService = homeServiceService;
            _hub = hub;
        }

        [HttpPost("send")]
        [Authorize(Roles = "Client,ServiceProvider")]
        public IActionResult CreateServiceQuery([FromForm] AddServiceQuariesVM model)
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(UserId))
                return new JsonResult("User not authenticated.") { StatusCode = 401 };

            if (model.IsSenderClient)
            {
                model.ClientId = UserId;
            }
            else
            {
                model.ServiceProviderId = UserId;
            }
            var result = _homeServiceService.CreateServiceQuery(model);
            if (!result.Success)
                return new JsonResult(result.Message);
             _hub.Clients.User(model.IsSenderClient? model.ServiceProviderId : model.ClientId).SendAsync("ReceiveMessage", model);
            return new JsonResult(result);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetQueriesByCategory(
            int categoryId)
        {
            var result = _homeServiceService.GetQueriesByCategory(categoryId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("client")]
        //[Authorize(Roles = "Client")]
        public IActionResult GetQueriesByClient()
        {
            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetQueriesByClient(clientId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpGet("provider")]
        //[Authorize(Roles = "ServiceProvider")]
        public IActionResult GetQueriesByProvider()
        {
            var providerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetQueriesByProvider(providerId);
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
        //[Authorize(Roles = "Client")]
        public IActionResult UpdateServiceQuery(int id, [FromForm] AddServiceQuariesVM model)
        {
            var result = _homeServiceService.UpdateServiceQuery(id, model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Client")]
        public IActionResult DeleteServiceQuery(int id)
        {
            var result = _homeServiceService.DeleteServiceQuery(id);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }
    }
}