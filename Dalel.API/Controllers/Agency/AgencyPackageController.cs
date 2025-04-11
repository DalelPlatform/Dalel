using Dalel.Services;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Controllers.Agency
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyPackageController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        AgencyPackageController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }
        [HttpGet]
        public IActionResult GetAlldoc(int id)
        {

            var res = _pakageService.GetAllVerificationDocument(id);
            return new JsonResult(res);
        }
        [HttpPost]
        public IActionResult AddDocAddDocument(int agencyId, string documentType,
            string documentFile)
        {

           var res= _pakageService.AddDocument(agencyId,documentType,documentFile);
            return new JsonResult(res);
        }
        [HttpPut]
        public IActionResult UpdateDoc(addAgencyVerificationDocumentVM doc) 
        {
            var res = _pakageService.UpdateDocument(doc.ToModel());
            return new JsonResult(res);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDoc(int id) {
            var res = _pakageService.delecteDocument(id);
            return new JsonResult(res);

        }
    }
}
