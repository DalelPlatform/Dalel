using Dalel.Services.Agency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Controllers.Agency
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelAgenciesController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        TravelAgenciesController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }
    }
}
