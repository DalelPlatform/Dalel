using Microsoft.AspNetCore.Mvc;

namespace Dalel.API.Controllers.Agency
{
    public class AgencyPackage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
