using System.Security.Claims;
using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Dalel.ViewModels.Agency.TravelAgencies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.API.Areas.Agency.Controllers
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

        [HttpGet("search")]
        public IActionResult SearchTravelAgencies(
              [FromQuery] string searchText = "",
              [FromQuery] string BusinessCategory = "",
              [FromQuery] string Address = "",
              [FromQuery] string? owner = "",
              [FromQuery] List<string>? Category = null,
              [FromQuery] int pageSize = 10,
              [FromQuery] int pageIndex = 1,
              [FromQuery] string OrderBy = "Id",
              [FromQuery] bool IsAscending = false)
        {
            var result = _pakageService.SearchTravelAgencies(
                searchText,
                BusinessCategory,
                Address,
                owner,
                Category,
                pageSize,
                pageIndex,
                OrderBy,
                IsAscending
            );

            if (!result.Success)
                return new JsonResult(result);

            return new JsonResult(result);
        }
        [HttpGet]
        public IActionResult GetAllTravels()
        {
            var ownerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var res = _pakageService.GetAllTravelAgency(ownerId);
            return new JsonResult(res);
        }
        [HttpPost]

        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        [Consumes("multipart/form-data")]
        public IActionResult AddTravelAgency([FromForm] addTravelAgenciesVM trvelAgency)
        {

            trvelAgency.ownerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Console.WriteLine("ownerId from JWT: " + trvelAgency.ownerId);

            var res = _pakageService.CreateTravelAgencies(trvelAgency);
            return new JsonResult(res);
        }
        [HttpPut("{Id}")]
        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        public IActionResult UpdateTravelAgency(addTravelAgenciesVM trvelAgency,int Id)
        {
            var res = _pakageService.UpdateTravelAgencies(Id,trvelAgency);
            return new JsonResult(res);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        public IActionResult DeleteTravelAgency(int id)
        {
            var res = _pakageService.deleteTravelAgencies(id);
            return new JsonResult(res);

        }
    }
}
