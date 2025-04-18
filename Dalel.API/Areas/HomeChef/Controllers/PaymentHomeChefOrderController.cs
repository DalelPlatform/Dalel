using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.HomeChef;

namespace Dalel.API.Areas.HomeChef.Controllers

{

    [ApiController]
    [Route("api/[controller]")]
    public class PaymentHomeChefOrderController : Controller
    {

        private readonly HomeChefService _homeChefService;

        public PaymentHomeChefOrderController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }



        [Authorize(Roles = "Client,Admin,HomeChef")]


        [HttpPost("AddPayment")]
        public IActionResult Addpayment(AddPaymentHomeChefOrderVM PayVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.AddPayment(PayVm);

            if (result.Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result.Message);

        }




        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("UpdatePayment/{id}")]

        public IActionResult UpdatePayment(int id ,AddPaymentHomeChefOrderVM PayVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdatePayment(id,PayVm);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }




        [Authorize(Roles = "Admin,HomeChef")]
        [HttpPost("DeletePaymentById")]

        public IActionResult DeletePayment(int id)
        {
            var result = _homeChefService.DeletePayment(id);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }
    }
}
