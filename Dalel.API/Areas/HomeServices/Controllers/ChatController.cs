using Dalel.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

    }
}
