using Dalel.Reopsitory;
using Dalel.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.hotel
{
    public class BookingHotelRoomController : Controller
    {
        private BookingHotelRoomRepository Bookinghotel { get; set; }
        public BookingHotelRoomController(BookingHotelRoomRepository _Bookinghotel)
        {
            
            Bookinghotel = _Bookinghotel;
        }

        public IActionResult Pending()
        {

            var pendingbook = Bookinghotel.GetPendingBooking().ToList();
            return View(pendingbook);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            Bookinghotel.UpdateBookingStatus(id, BookingStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            Bookinghotel.UpdateBookingStatus(id, BookingStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
