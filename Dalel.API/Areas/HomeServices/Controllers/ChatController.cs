using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Dalel.API.Areas.HomeServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly HomeServiceService _homeServiceService;

        public ChatController(HomeServiceService homeServiceService)
        {
            _homeServiceService = homeServiceService;
        }
        [HttpGet ("Chat")]
        [Authorize(Roles = "ServiceProvider,Client")]
        public IActionResult GetChats()
        {
            var UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _homeServiceService.GetChatsForUser(UserId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpPost]
        [Authorize(Roles = "ServiceProvider,Client")]
        public IActionResult CreateChat([FromForm] AddChatVM model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (User.IsInRole("Client"))
                model.ClientId = userId;
            else if (User.IsInRole("ServiceProvider"))
                model.ServiceProviderId = userId;

            var existingChatResult = _homeServiceService.GetChatBetween(model.ClientId, model.ServiceProviderId);

            if (existingChatResult.Success)
            {
                return new JsonResult(existingChatResult);
            }
            var result = _homeServiceService.CreateChat(model);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }


    }
}
