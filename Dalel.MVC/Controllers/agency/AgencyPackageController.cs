using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.agency
{
    public class AgencyPackageController : Controller
    {
        private AgencyPackageRepo agencypackageRepo { get; set; }
        public AgencyPackageController(AgencyPackageRepo _agencypackageRepo)
        {
            agencypackageRepo = _agencypackageRepo;
        }
        public IActionResult Pending()
        {

            var pending = agencypackageRepo.GetPendingPackage().ToList();
            return View(pending);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            agencypackageRepo.UpdatepackageStatus(id, VerificationStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            agencypackageRepo.UpdatepackageStatus(id, VerificationStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
