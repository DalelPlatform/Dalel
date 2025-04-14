using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dalel.Services;
using Dalel.ViewModels.HomeServices.CategoryServices;
using Dalel.Services.HotelService;
using Dalel.Services.ServiceProvicerService;

namespace Controllers
{
    //[Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly Services _service;

        public CategoryController(Services service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categories = _service.GetCategories();
            return View(categories.Data);
        }

        public IActionResult Details(int id)
        {
            var categoryResult = _service.GetCategoryById(id);

            if (!categoryResult.Success || categoryResult.Data == null)
            {
                TempData["Error"] = categoryResult.Message;
                return RedirectToAction("Index"); 
            }

            return View(categoryResult.Data);
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
            return View(category.Data);
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
            return View(category.Data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}