using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Restaurant.Enums;

namespace Models.Restaurant
{
    public class RestaurantOrders
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public float TotalPrice { get; set; }

        public StatusOfOrder OrderStatus { get; set; }

        public int RestaurantId { get; set; } //fk

        public string ClientId { get; set; } // fk
    }
}
