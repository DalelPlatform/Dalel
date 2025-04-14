using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.HomeChef;

namespace Dalel.API.Controllers.HomeChef
{
    public class PaymentHomeChefOrderController : Controller
    {

        private readonly HomeChefService _homeChefService;

        public PaymentHomeChefOrderController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }



        [Authorize(Roles = "Client,Admin,HomeChef")]


        [HttpPost("AddOrder")]
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
        [HttpPost("UpdateOrder")]

        public IActionResult UpdatePayment(AddPaymentHomeChefOrderVM PayVm)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdatePayment(PayVm);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }




        [Authorize(Roles = "Admin,HomeChef")]
        [HttpPost("DeleteMealById")]

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
