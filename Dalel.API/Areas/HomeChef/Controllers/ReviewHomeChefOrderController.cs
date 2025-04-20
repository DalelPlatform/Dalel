using Dalel.Services;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Areas.HomeChef.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ReviewHomeChefOrderController : Controller
    {
        private readonly HomeChefService _homeChefService;

        public ReviewHomeChefOrderController(HomeChefService homeChefService)
        {
            _homeChefService = homeChefService;
        }



        [HttpGet("search")]
        public IActionResult Search(
          string searchText = "",
          float? rating = null,
          DateTime? fromDate = null,
          DateTime? toDate = null,
          string? homeChefId = null,
          int? orderId = null,
          int pageSize = 10,
          int pageIndex = 1,
          string orderBy = "Id",
          bool isAscending = false)
        {
            var result = _homeChefService.Search(
                searchText,
                rating,
                fromDate,
                toDate,
                homeChefId,
                orderId,
                pageSize,
                pageIndex,
                orderBy,
                isAscending
            );

            if (!result.Success)
                return new JsonResult(result);

            return new JsonResult(result);
        }



        [Authorize(Roles = "Client,Admin,HomeChef")]


        [HttpPost("AddReview")]
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
        [HttpPost("UpdateReview/{id}")]

        public IActionResult UpdateReview(int id,AddReviewHomeChefOrderVM Review)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Invalid data provided");
            }

            var result = _homeChefService.UpdateReview(id,Review);
            if (result.Success)
            {
                return new JsonResult(result);
            }

            return new JsonResult(result);
        }




        [Authorize(Roles = "Admin,HomeChef")]
        [HttpPost("DeleteReviewById")]

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
