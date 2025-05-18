using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.agency
{
    public class AgencyPromotionController : Controller
    {
        private AgencyPromotionRepo AgencyPromotionRepo { get; set; }
        public AgencyPromotionController(AgencyPromotionRepo _AgencyPromotionRepo)
        {
            AgencyPromotionRepo = _AgencyPromotionRepo;
        }
        public IActionResult Pending()
        {

            var pending = AgencyPromotionRepo.GetPendingPromotion().ToList();
            return View(pending);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            AgencyPromotionRepo.UpdatePromotionStatus(id, VerificationStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            AgencyPromotionRepo.UpdatePromotionStatus(id, VerificationStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
