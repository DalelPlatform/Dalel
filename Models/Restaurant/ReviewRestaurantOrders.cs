using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Restaurant
{
    public class ReviewRestaurantOrders
    {
        public int Id { get; set; }

        public string Comments { get; set; }

        public DateTime ModificationDateTime { get; set; }

        public string ClientId { get; set; } //fk

        public int RestaurantOrderId { get; set; } // fk
    }
}
