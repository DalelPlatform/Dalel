using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.PackageStep;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Models.Agency;
using Utilities;

namespace Dalel.API.Controllers.Agency
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageStepController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public PackageStepController(AgencyPakageService pakageService)
        {
            _pakageService = pakageService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var steps = _pakageService.GetAllPackageStep();
            return new JsonResult(steps);
        }
        [HttpPost]
        public IActionResult Create([FromBody] addPackageStepVM step)
        {
            var result = _pakageService.CreatePackageStep(step);
            try
            {
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ServiceResult<PackageStep>.FailureResult("Error: " + ex.Message);
            }


        }
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] addPackageStepVM step)
        {
            var result = _pakageService.UpdatePackageStep(step);
            return new JsonResult(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pakageService.deletePackageStep(id);
            return new JsonResult(false);
        }
    }
}
