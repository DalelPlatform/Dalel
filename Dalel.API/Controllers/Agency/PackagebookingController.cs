using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Controllers.Agency
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagebookingController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        PackagebookingController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }
        public IActionResult UpdateBooking(AddPackagebookingVM book)
        {
            var res = _pakageService.updataBooking(book.ToModel());
            return new JsonResult(res);
        }
        [HttpDelete("{id}")]
        public IActionResult UpdateBooking(int id)
        {
            var res = _pakageService.delecteBooking(id);
            return new JsonResult(res);

        }
    }
}
