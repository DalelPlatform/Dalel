using System.Security.Claims;
using Dalel.Services.Agency;
using Dalel.ViewModels.Agency.AgencyReview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas.Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class packageReviewController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public packageReviewController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }

        [HttpPost]
        [Authorize(Roles = "Client")]
        public IActionResult AddPackageReview([FromBody]AddAgencyReview reviewVM)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _pakageService.AddPackageReview(reviewVM,userId);
            if (!result.Success)
                return new JsonResult(result.Message) { StatusCode = 400 };
            return new JsonResult(result);
        }
        [HttpGet("GetPackageReviews/{packageId}")]
        public IActionResult GetPackageReviews(int packageId)
        {
            var reviews = _pakageService.getPackageReviews(packageId);
            return new JsonResult(reviews);
          
        }
        }
}
