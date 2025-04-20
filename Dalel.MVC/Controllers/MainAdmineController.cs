using Dalel.Services;
using Dalel.Services.Agency;
using Dalel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dalel.MVC.Controllers
{
    public class MainAdmineController : Controller
    {
        private PendingRequestService PendingRequestService;
        public MainAdmineController(PendingRequestService _PendingRequestService,
            AgencyPakageService _AgencyPakageService)
        {
            PendingRequestService = _PendingRequestService;
            
        }
        public IActionResult MainDashboard()
        { 

          var docsVerify = PendingRequestService.GetPendingAgencyRequests().ToList();
            Console.WriteLine("Docs Count: " + docsVerify.Count);
            var model = new AdminDashboardViewModel
            {
                Documents = docsVerify,
            };
          return View(model);
            
        }
        public IActionResult AcceptRequest(int id, string requestType)
        {
            PendingRequestService.AcceptRequest(id, requestType);
            return RedirectToAction("Dashboard");
        }
        public IActionResult RejectRequest(int id, string requestType)
        {
            PendingRequestService.RejectRequest(id, requestType);
            return RedirectToAction("Dashboard");
        }
    }
}
