using Dalel.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.homeService
{
    public class ServiceRequestController : Controller
    {
        public ServiceRequestRepository Repository { get; set; }
        public ServiceRequestController(ServiceRequestRepository _Repository)
        {
            Repository = _Repository;
        }
        public IActionResult Pending()
        {

            var pendingReq = Repository.GetPendingRequests().ToList();
            return View(pendingReq);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            Repository.UpdaterequestsStatus(id, RequestStatus.Completed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            Repository.UpdaterequestsStatus(id, RequestStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
