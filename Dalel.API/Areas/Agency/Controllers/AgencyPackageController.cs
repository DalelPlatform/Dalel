using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Hotel;

namespace Dalel.API.Areas.Agency.Controllers
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
        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        public IActionResult createAgencyPackage([FromForm] AddAgencyPackageVM packageAgency)
        {
            //user claim    
            var res = _pakageService.CreateAgencyPackage(packageAgency);
            return new JsonResult(res);
        }
        [HttpPut("{Id}")]
        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        public IActionResult UpdateAgecyPackage(AddAgencyPackageVM packageAgency, int Id)
        {
            var res = _pakageService.UpdateAgencyPackage(Id, packageAgency);
            return new JsonResult(res);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        public IActionResult DeleteAgecyPackage(int id)
        {
            var res = _pakageService.deleteAgencyPackage(id);
            return new JsonResult(res);

        }

        [HttpGet("search")]
        public IActionResult SearchAgencyPackage(
               [FromQuery] string searchText = "",
              [FromQuery] string Name = "",
               [FromQuery] string Price = "",

               [FromQuery] int pageSize = 10,
              [FromQuery] int pageIndex = 1,
               [FromQuery] string OrderBy = "Id",
               [FromQuery] bool IsAscending = false
           )
        {
            var result = _pakageService.SearchAgencyPackage(
                 searchText,
                       Name,
                       Price,

                       pageSize,
                       pageIndex,
                       OrderBy,
                      IsAscending
            );

            if (!result.Success)
                return new JsonResult(result);

            return new JsonResult(result);
        }


    }
}