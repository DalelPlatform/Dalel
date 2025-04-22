using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.Packagebooking;
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
    }
}