using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.AgencyVerificationDocument;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas.Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyVerificationDocumentController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public AgencyVerificationDocumentController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }



        [HttpGet]
        [Authorize(Roles = "TravelAgencyOwner,Admin")]
        public IActionResult GetAlldoc(int id)
        {

            var res = _pakageService.GetAllVerificationDocument(id);
            return new JsonResult(res);
        }
        [HttpPost]

        public IActionResult AddDocAddDocument(int agencyId, string documentType,
            string documentFile)
        {

            var res = _pakageService.AddDocument(agencyId, documentType, documentFile);
            return new JsonResult(res);
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateDoc(int Id, addAgencyVerificationDocumentVM doc)
        {
            var res = _pakageService.UpdateDocument(Id, doc);
            return new JsonResult(res);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDoc(int id)
        {
            var res = _pakageService.delecteDocument(id);
            return new JsonResult(res);

        }

    }
}