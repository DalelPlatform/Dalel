using Dalel.Repository;
using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.properity
{
    public class BookingPropertiesController : Controller
    {
        private BookingPropertiesRepository BookingProperties { get; set; }
        public BookingPropertiesController(BookingPropertiesRepository _BookingProperties)
        {
            BookingProperties = _BookingProperties;
        }
        public IActionResult Pending()
        {

            var pendingbooking = BookingProperties.GetPendingBooking().ToList();
            return View(pendingbooking);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            BookingProperties.UpdateBookingStatus(id, BookingStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            BookingProperties.UpdateBookingStatus(id, BookingStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
