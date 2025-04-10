using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Models;
using Models.HomeChef;

namespace Dalel.Repository
{
    public class HomeChefOrderMealRepository : BaseRepository<HomeChefOrderMeal>
    {
        public HomeChefOrderMealRepository(DelelContext dalel ): base(dalel)
        {
            
        }


        public HomeChefOrderMealDetailsVM ? GetOrderMealById(int id)

        {
                return base.GetList(m => m.Id == id)
                .Select(m => new HomeChefOrderMealDetailsVM()).FirstOrDefault();
        }


        public List<HomeChefOrderMealDetailsVM> GetMealsByOrderId(int id)
        {
            return base.GetList(o => o.HomeChefOrdersId == id)
                .Select(meals => new HomeChefOrderMealDetailsVM()).ToList();
        }


        public List<HomeChefOrderMealDetailsVM> GetMealsByMealId(int id)
        {
            return base.GetList(m => m.HomeChefMealsId == id)
                .Select(meals => new HomeChefOrderMealDetailsVM() ).ToList();
        }



    }
}
