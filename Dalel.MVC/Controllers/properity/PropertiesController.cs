using Dalel.Repository;
using Dalel.Repository.Agency;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Dalel.MVC.Controllers.properity
{
    public class PropertiesController : Controller
    {
        private PropertiesRepository Properties { get; set; }
        public PropertiesController(PropertiesRepository _Properties)
        {
            Properties = _Properties;
        }
        public IActionResult Pending()
        {

            var pending = Properties.GetPendingProperties().ToList();
            return View(pending);
        }
        [HttpPost]
        public IActionResult Accept(int id)
        {
            Console.WriteLine(id);
            Properties.UpdateVerificationStatus(id, VerificationStatus.Confirmed);
            return RedirectToAction("Pending");
        }
        [HttpPost]
        public IActionResult Reject(int id)
        {
            Console.WriteLine("reg", id);
            Properties.UpdateVerificationStatus(id, VerificationStatus.Rejected);
            return RedirectToAction("Pending");
        }
    }
}
