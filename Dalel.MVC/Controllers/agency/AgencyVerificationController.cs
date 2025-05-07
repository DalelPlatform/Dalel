using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.agency
{
    public class AgencyVerificationController : Controller
    {
        private AgencyVerificationDocumentRepo VerificationDocumentRepo { get; set; }
        public AgencyVerificationController(AgencyVerificationDocumentRepo _AgencyVerificationDocumentRepo)
        {
            VerificationDocumentRepo = _AgencyVerificationDocumentRepo;
        }
        public IActionResult Pending()
        {

            var pendingDoc= VerificationDocumentRepo.GetPendingDocuments().ToList();
            return View(pendingDoc);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            VerificationDocumentRepo.UpdateDocumentStatus(id,VerificationStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg",id);
            VerificationDocumentRepo.UpdateDocumentStatus(id, VerificationStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
