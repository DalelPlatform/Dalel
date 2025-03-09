using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Restaurant
{
    public class RestaurantMenuItemImages
    {
        public int Id { get; set; } //pk

        public string Image {  get; set; }

        public int RestaurantMenuItemId { get; set; } //fk
    }
}
