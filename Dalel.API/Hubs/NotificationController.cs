using Dalel.Services;
using Dalel.ViewModels.notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Hubs
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

            private readonly NotificationService _service;

            public NotificationController(NotificationService service)
            {
                _service = service;
            }

            [HttpPost]
            public async Task<IActionResult> Send(AddNotificationVM model)
            {
                await _service.SendNotificationAsync(model);
                return Ok("Notification sent.");
            }

            [HttpGet("{userId}")]
            public async Task<IActionResult> Get(string userId)
            {
                var result = await _service.GetNotificationsAsync(userId);
                return Ok(result);
            }
        }

}
