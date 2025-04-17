using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Hotel;

namespace Dalel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyPackageController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
       public AgencyPackageController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }

        [HttpGet]
        public IActionResult GetAllAgencyPackage(int id)
        {

            var res = _pakageService.GetAllAgencyPackage(id);
            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult createAgencyPackage(AddAgencyPackageVM packageAgency)
        {

            var res = _pakageService.CreateAgencyPackage(packageAgency);
            return new JsonResult(res);
        }
        [HttpPut]
        public IActionResult UpdateAgecyPackage(AddAgencyPackageVM packageAgency)
        {
            var res = _pakageService.UpdateAgencyPackage(packageAgency);
            return new JsonResult(res);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAgecyPackage(int id)
        {
            var res = _pakageService.deleteAgencyPackage(id);
            return new JsonResult(res);

        }

       


    }
}
