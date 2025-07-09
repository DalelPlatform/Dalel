using System.Security.Claims;
using Dalel.Services.Agency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas.Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public NotificationsController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }
        [HttpGet]
        public IActionResult GetNotifications()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var notifications = _pakageService.GetUserNotifications(userId);
            return new JsonResult(notifications);
        }
        [HttpPost("{id}/mark-as-read")]
        public IActionResult MarkAsRead(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _pakageService.MarkAsRead(id, userId);
            return Ok();
        }
    }
}
