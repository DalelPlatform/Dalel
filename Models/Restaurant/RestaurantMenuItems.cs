using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Restaurant.Enums;

namespace Models.Restaurant
{
    public class RestaurantMenuItems
    {
        public int Id { get; set; }

        public enTypeOfFood Type {  get; set; } // convert to int

        public string Description { get; set; }
        public enSizeOfPiece Size { get; set; }

        public double Duration { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int RestaurantId { get; set; } //fk from Restaurant
    }
}
