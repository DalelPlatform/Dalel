using Dalel.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.HomeService;
using System.Security.Claims;

namespace Dalel.MVC.Controllers
{
    [Area("Admin")]
    public class CategoryServicesController : Controller
    {
        private CategoryServicesRepo repository;

        public CategoryServicesController(CategoryServicesRepo repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            var list = repository.Get().ToList();

            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryServices category)
        {
            if (ModelState.IsValid)
            {
                repository.Add(category);
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id, string name)
        {
            var selected = repository.GetList(i => i.Id == Id).FirstOrDefault();
            return View(selected);
        }
        [HttpPost]
        public IActionResult Edit(CategoryServices category)
        {
            repository.Update(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var classroom = repository.GetList(r => r.Id == id).FirstOrDefault();
            repository.Delete(classroom);
            return RedirectToAction("index");
        }
    }
}
