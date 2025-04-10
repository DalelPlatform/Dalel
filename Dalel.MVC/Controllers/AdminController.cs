using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dalel.Services;
using Dalel.ViewModels.HomeServices.CategoryServices;
using Dalel.Services.HomeService;
using Dalel.Services.ServiceProvicerService;

namespace Controllers
{
    [Authorize(Roles = "Admin")]
    public class Category : Controller
    {
        private readonly Services _service;

        public Category(Services service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categories = _service.GetCategories();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = _service.GetCategoryById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        public IActionResult Create()
        {
            return View(new AddCategoryServicesVM());
        }

        [HttpPost]
        public IActionResult Create(AddCategoryServicesVM vm)
        {
            if (ModelState.IsValid)
            {
                _service.AddCategory(vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult Edit(int id)
        {
            var category = _service.GetCategoryById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryServicesDetailsVM vm)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCategory(vm);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            var category = _service.GetCategoryById(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}