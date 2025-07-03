using System.Security.Claims;
using Dalel.API.Areas.Agency.Hup;
using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels.notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Dalel.API.Areas.Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagebookingController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public readonly IHubContext<NotificationHub> _hubContext;
        public PackagebookingController(AgencyPakageService _service,
            IHubContext<NotificationHub> hubContext)
        {
            _pakageService = _service;
            _hubContext = hubContext;
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateBooking(int Id, AddPackagebookingVM book)
        {
            var res = _pakageService.updataBooking(Id, book);
            return new JsonResult(res);
        }
        //[HttpDelete("{id}")]
        //public IActionResult delecteBooking(int id)
        //{
        //    var res = _pakageService.delecteBooking(id);
        //    return new JsonResult(res);

        //}



        [HttpPost("Booking")]
        [Authorize(Roles ="Client")]
        public  IActionResult BookPackage([FromBody] AddPackagebookingVM booking)
        {
            booking.ClientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _pakageService.BookPackage(booking);
            if (!result.Success)
                return new JsonResult(result.Message) { StatusCode = 400 };
            var notificationData = _pakageService.GetOwnerIdBySchaduleId(booking.PackageSchaduleId);

            var Message = $"New booking: {notificationData.Package.Name} " +
                $"on {booking.Date} for {notificationData.Package.Price} $";
            Console.WriteLine($"📢 Sending notification to group: " +
                $"{notificationData.OwnerId}");
            var savedNotification = _pakageService.AddNotification(new AddNotificationVM
            {
                UserId = notificationData.OwnerId,
                Message = Message
            });
            var notificationVM = savedNotification.ToDetailsVM();

            _hubContext.Clients.Group(notificationData.OwnerId).
                SendAsync("ReceiveNotification", notificationVM);
           return new JsonResult(result);
        }
        [HttpGet("Booking")]
        [Authorize(Roles = "Client")]
        public IActionResult getAllBooking() {

            var clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res = _pakageService.showAllBooking(clientId);

            return new JsonResult(res)
            {
                StatusCode = 200,
            };

        }

        [HttpDelete("{bookingId}")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var result = await _pakageService.CancelBooking(bookingId);
            if (!result.Success)
                return new JsonResult(result.Message) { StatusCode = 400};
            return new JsonResult(result);
        }

        [HttpGet("{bookingId}")]
        [Authorize(Roles = "Client")]
        public IActionResult GetBookingById(int bookingId)
        {
            var result = _pakageService.GetBookingById(bookingId);
            if (!result.Success)
                return new JsonResult(result.Message) { StatusCode = 400 };

            return new JsonResult(result);
        }
       
    }
}