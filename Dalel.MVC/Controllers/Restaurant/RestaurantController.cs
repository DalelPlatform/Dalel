using Dalel.Repository;
using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Restaurant.Enums;

namespace Dalel.MVC.Controllers.RestaurantReservation
{
    public class RestaurantController : Controller
    {
        private RestaurantRepository Restaurant { get; set; }
        public RestaurantController(RestaurantRepository _Restaurant)
        {
            Restaurant = _Restaurant;
        }
        public IActionResult Pending()
        {

            var pending = Restaurant.GetPendingRestaurant().ToList();
            return View(pending);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            Restaurant.UpdateRestaurantStatus(id, VerificationStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            Restaurant.UpdateRestaurantStatus(id, VerificationStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
