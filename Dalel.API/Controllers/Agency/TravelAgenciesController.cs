using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.TravelAgencies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Controllers.Agency
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelAgenciesController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public TravelAgenciesController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }
        [HttpGet]
        public IActionResult GetAllTravels(int id)
        {

            var res = _pakageService.GetAllTravelAgency();
            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult AddTravelAgency(addTravelAgenciesVM trvelAgency)
        {

            var res = _pakageService.CreateTravelAgencies(trvelAgency);
            return new JsonResult(res);
        }
        [HttpPut]
        public IActionResult UpdateTravelAgency(addTravelAgenciesVM trvelAgency)
        {
            var res = _pakageService.UpdateTravelAgencies(trvelAgency);
            return new JsonResult(res);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTravelAgency(int id)
        {
            var res = _pakageService.deleteTravelAgencies(id);
            return new JsonResult(res);

        }
    }
}
