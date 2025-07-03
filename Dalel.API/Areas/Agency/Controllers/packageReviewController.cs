using Dalel.Services.Agency;
using Dalel.ViewModels.Agency.AgencyReview;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var result = _pakageService.AddPackageReview(reviewVM);
            if (!result.Success)
                return new JsonResult(result.Message) { StatusCode = 400 };
            return new JsonResult(result);
        }
    }
}
