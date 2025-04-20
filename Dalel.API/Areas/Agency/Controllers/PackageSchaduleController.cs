using Dalel.Services.Agency;
using Dalel.ViewModels.Agency.PackageSchadule;
using Dalel.ViewModels.Agency.PackageStep;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Agency;
using Utilities;

namespace Dalel.API.Areas.Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageSchaduleController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public PackageSchaduleController (AgencyPakageService service)
        {
            _pakageService = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var Schadule = _pakageService.GetAllPackageSchadule();
            return new JsonResult(Schadule);
        }

        [HttpPost]
        public IActionResult Create([FromBody] addPackageSchaduleVM schadule)
        {
            var result = _pakageService.CreatePackageSchadule(schadule);
            try
            {
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ServiceResult<PackageSchadule>.FailureResult("Error: " + ex.Message);
            }


        }

        [HttpPut("{Id}")]
        public IActionResult Update(int Id,[FromBody] addPackageSchaduleVM schadule)
        {
            var result = _pakageService.UpdatePackageSchadule(Id,schadule);
            return new JsonResult(result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pakageService.deleteSchadule(id);
            return new JsonResult(false);
        }






    }

}
