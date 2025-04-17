using Dalel.Services;
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
       public PackagebookingController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }
        [HttpPut]
        public IActionResult UpdateBooking(AddPackagebookingVM book)
        {
            var res = _pakageService.updataBooking(book);
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
