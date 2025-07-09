using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.PackageBookingPayment;
using Dalel.ViewModels.Property.PaymentPropertiesDeails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas.Agency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AgencyPaymentController : ControllerBase
    {
        private readonly AgencyPakageService _pakageService;
        public AgencyPaymentController(AgencyPakageService _service)
        {
            _pakageService = _service;
        }

        [HttpPost("Payment")]
        [Authorize(Roles = "Client")]
        public async Task<IActionResult> AddPayment(AddAgencyPaymentVM payment)
        {
            var result = await _pakageService.AddPayment(payment.ToModel());
            if (!result.Success)
                return new JsonResult(result.Message) { StatusCode = 400 };
            return new JsonResult(result);
        }
    }


}
