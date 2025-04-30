using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.agency
{
    public class TravelAgenciesController : Controller
    {
        private TravelAgenciesRepo TravelAgenciesRepo { get; set; }
        public TravelAgenciesController(TravelAgenciesRepo _TravelAgenciesRepo)
        {
            TravelAgenciesRepo = _TravelAgenciesRepo;
        }
        public IActionResult Pending()
        {

            var pending= TravelAgenciesRepo.GetPendingTravelAgencies().ToList();
            return View(pending);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            TravelAgenciesRepo.UpdateTravelAgenciesStatus(id, VerificationStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            TravelAgenciesRepo.UpdateTravelAgenciesStatus(id, VerificationStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
