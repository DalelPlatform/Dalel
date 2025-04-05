using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.Repository;
using Models.HomeService;

namespace Dalel.Services.RestaurantServices
{
    public class RestaurantService 

    {
        public readonly RestaurantRepository _RestaurantRepo; 


        public RestaurantService(RestaurantRepository restaurantRepo)
        {
            _RestaurantRepo = restaurantRepo;
        }



        //public Task<IActionResult> CreateRestaurant ()
        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(CategoryServices category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.Add(category);
        //        return RedirectToAction("index");
        //    }
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Edit(int Id, string name)
        //{
        //    var selected = repository.GetList(i => i.Id == Id).FirstOrDefault();
        //    return View(selected);
        //}
        //[HttpPost]
        //public IActionResult Edit(CategoryServices category)
        //{
        //    repository.Update(category);
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Delete(int id)
        //{
        //    var classroom = repository.GetList(r => r.Id == id).FirstOrDefault();
        //    repository.Delete(classroom);
        //    return RedirectToAction("index");
        //}
    }
}
