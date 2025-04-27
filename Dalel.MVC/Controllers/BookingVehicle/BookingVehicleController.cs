using Dalel.Reopsitory;
using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.BookingVehicle
{
    public class BookingVehicleController : Controller
    {
        private BookingVehicleRepository BookingVehicle { get; set; }
        public BookingVehicleController(BookingVehicleRepository _BookingVehicle)
        {
            BookingVehicle = _BookingVehicle;
        }

        public IActionResult Pending()
        {

            var pendingbook = BookingVehicle.GetPendingBooking().ToList();
            return View(pendingbook);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            BookingVehicle.UpdateBookingStatus(id,BookingStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            BookingVehicle.UpdateBookingStatus(id, BookingStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
