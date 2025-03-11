using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeChef
{
    public class HomeChefMealImages
    {
        public int Id { get; set; }
        public string Image {  get; set; }

        public int MealId { get; set; }

    }
}
