using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.HomeChef;

namespace Dalel.Repository.HomeChef
{
    public class HomeChefMealRepository : BaseRepository<HomeChefMeal>
    {
        public HomeChefMealRepository(DelelContext dalelContext) : base(dalelContext) 
        {

        }


        //Get Meals by Chef ID 
        //public HomeChefMealDetailsVM GetMealsByChefId(int chefId)
        //{

        //}
    }
}
