//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Dalel.Services.HomeService;
//using Dalel.ViewModels.HomeServices.CategoryServices;
//using Utilities;
//using Dalel.Services.ServiceProvicerService;

//namespace Controllers
//{
//    [Authorize(Roles = "Admin")]
//    public class Category : Controller
//    {
//        private readonly Services _service;

//        public Category(Services service)
//        {
//            _service = service;
//        }

//        public IActionResult Index()
//        {
//            var result = _service.GetCategories();
//            if (!result.Success)
//            {
//                TempData["Error"] = result.Message;
//                return View(new List<CategoryServicesDetailsVM>());
//            }
//            var categories = result.Data.ToList();
//            return View(categories);
//        }

//        public IActionResult Details(int id)
//        {
//            var result = _service.GetCategoryById(id);
//            if (!result.Success)
//            {
//                TempData["Error"] = result.Message;
//                return result.StatusCode switch
//                {
//                    404 => NotFound(),
//                    _ => RedirectToAction("Index")
//                };
//            }
//            return View(result.Data);
//        }

//        public IActionResult Create()
//        {
//            return View(new AddCategoryServicesVM());
//        }

//        [HttpPost]
//        public IActionResult Create(AddCategoryServicesVM vm)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(vm);
//            }

//            var result = _service.AddCategory(vm);
//            if (!result.Success)
//            {
//                TempData["Error"] = result.Message;
//                return View(vm);
//            }

//            TempData["Success"] = result.Message;
//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            var result = _service.GetCategoryById(id);
//            if (!result.Success)
//            {
//                TempData["Error"] = result.Message;
//                return result.StatusCode switch
//                {
//                    404 => NotFound(),
//                    _ => RedirectToAction("Index")
//                };
//            }
//            return View(result.Data);
//        }

//        [HttpPost]
//        public IActionResult Edit(CategoryServicesDetailsVM vm)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(vm);
//            }

//            var result = _service.UpdateCategory(vm);
//            if (!result.Success)
//            {
//                TempData["Error"] = result.Message;
//                return View(vm);
//            }

//            TempData["Success"] = result.Message;
//            return RedirectToAction("Index");
//        }

//        public IActionResult Delete(int id)
//        {
//            var result = _service.GetCategoryById(id);
//            if (!result.Success)
//            {
//                TempData["Error"] = result.Message;
//                return result.StatusCode switch
//                {
//                    404 => NotFound(),
//                    _ => RedirectToAction("Index")
//                };
//            }
//            return View(result.Data);
//        }

//        [HttpPost, ActionName("Delete")]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var result = _service.DeleteCategory(id);
//            if (!result.Success)
//            {
//                TempData["Error"] = result.Message;
//                return RedirectToAction("Index");
//            }

//            TempData["Success"] = result.Message;
//            return RedirectToAction("Index");
//        }
//    }
//}