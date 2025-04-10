using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Dalel.Repository
{
    public class HomeChefMealImageRepository : BaseRepository<HomeChefMealImageRepository>
    {


        public HomeChefMealImageRepository (DelelContext dalel) : base(dalel)
        {

        }
    }
}
