using System.Security.Claims;
using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Hotel;
using Newtonsoft.Json.Linq;

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
        [HttpGet("{id}")]
        public IActionResult GetAgencyPackagebyid(int id)
        {

            var res = _pakageService.Getpackagebyid(id);
            return new JsonResult(res);
        }

        [HttpPost]
        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        public IActionResult createAgencyPackage([FromForm] AddAgencyPackageVM packageAgency)
        {
           
            //packageAgency.AgencyId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine(User.Claims);
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
               [FromQuery] float Price = 0,

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
                return new JsonResult(result) { StatusCode = 400 };

            return new JsonResult(result);
        }

        [HttpGet("TopPackages")]
        public IActionResult GetTopPackages()
        {
            var result = _pakageService.GetTopBookedPackages();
         
            return new JsonResult(result);
        }
        }
}