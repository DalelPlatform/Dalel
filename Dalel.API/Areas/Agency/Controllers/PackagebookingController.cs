using System.Security.Claims;
using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas.Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagebookingController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public PackagebookingController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateBooking(int Id, AddPackagebookingVM book)
        {
            var res = _pakageService.updataBooking(Id, book);
            return new JsonResult(res);
        }
        [HttpDelete("{id}")]
        public IActionResult delecteBooking(int id)
        {
            var res = _pakageService.delecteBooking(id);
            return new JsonResult(res);

        }



        [HttpPost("Booking")]
        [Authorize(Roles ="Client")]
        public IActionResult BookProperty([FromBody] AddPackagebookingVM booking)
        {
            booking.ClientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _pakageService.BookPackage(booking);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }

        [HttpDelete("{bookingId}")]
        [Authorize("Client")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var result = await _pakageService.CancelBooking(bookingId);
            if (!result.Success)
                return new JsonResult(result.Message);
            return new JsonResult(result);
        }



    }
}