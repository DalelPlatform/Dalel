using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Restaurant
{
    public class RestaurantImages
    {
        public int Id { get; set; }
        public string Image {  get; set; }

        public int RestaurantId { get; set; }
    }
}
