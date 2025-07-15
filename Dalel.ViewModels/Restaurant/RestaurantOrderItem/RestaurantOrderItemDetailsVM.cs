using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Restaurant
{
    public class RestaurantOrderItemDetailsVM
    {
        public int Id { get; set; }

        public float SupPrice { get; set; }

        public float Quantity { get; set; }

        public int RestaurantOrderId { get; set; } //fk

        public int RestaurantMenuItemId { get; set; } //fk

        public int RestaurantId { get; set; }
        public string? RestaurantName { get; set; }

    }
}
