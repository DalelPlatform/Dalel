using Dalel.Reopsitory;
using Dalel.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.hotel
{
    public class HotelController : Controller
    {
        private HotelRepository hotel { get; set; }
        public HotelController(HotelRepository _hotel)
        {

             hotel = _hotel;
        }

        public IActionResult Pending()
        {

            var pending = hotel.GetPendingHotel().ToList();
            return View(pending);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            hotel.UpdateHotelStatus(id, VerificationStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            hotel.UpdateHotelStatus(id, VerificationStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
