using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Controllers.HomeChef
{
    public class ReviewHomeChefOrderController : Controller
    {
        private readonly HomeChefService _homeChefService;

        public ReviewHomeChefOrderController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }



        [Authorize(Roles = "Client,Admin,HomeChef")]


        [HttpPost("AddOrder")]
        public IActionResult AddReview(AddReviewHomeChefOrderVM Review)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.AddReview(Review);

            if (result.Success)
            {
                return new JsonResult(result);
            }
            return new JsonResult(result.Message);

        }


       

        [Authorize(Roles = "Client,Admin,HomeChef")]
        [HttpPost("UpdateOrder")]

        public IActionResult UpdateReview(AddReviewHomeChefOrderVM Review)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdateReview(Review);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }




        [Authorize(Roles = "Admin,HomeChef")]
        [HttpPost("DeleteMealById")]

        public IActionResult DeleteReview(int id)
        {
            var result = _homeChefService.DeleteReview(id);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }
    }
}
