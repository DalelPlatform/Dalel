using Dalel.Repository;
using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Restaurant.Enums;

namespace Dalel.MVC.Controllers.RestaurantReservation
{
    public class RestaurantReservationController : Controller
    {
        private RestaurantReservationRepository reserve { get; set; }
        public RestaurantReservationController(RestaurantReservationRepository _reserve)
        {
            reserve = _reserve;
        }
        public IActionResult Pending()
        {

            var pendingBooking = reserve.GetPendingBooking().ToList();
            return View(pendingBooking);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            reserve.UpdateReservationStatus(id, StatusOfReservations.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            reserve.UpdateReservationStatus(id, StatusOfReservations.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
