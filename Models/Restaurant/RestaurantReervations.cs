using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Restaurant.Enums;

namespace Models.Restaurant
{
    public class RestaurantReervations
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string TableNumber { get; set; }

        public StatusOfReervations ReervationStatus { get; set; }

        public int RestaurantId { get; set; } //fk

        public string ClientId { get; set; }//fk

        public string Comments { get; set; }

        public float Rating { get; set; }
    }
}
