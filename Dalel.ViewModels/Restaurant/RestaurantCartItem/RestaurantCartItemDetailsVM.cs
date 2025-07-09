using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class RestauranCartItemDetailsVM
    {
        public int Id { get; set; }

        public float SupPrice { get; set; }
        public float Quantity { get; set; }

        public string ClientId { get; set; }
        public string? ClientName { get; set; } // optional

        public int RestaurantMenuItemId { get; set; }
        public string? MenuItemName { get; set; } // optional
        public float? MenuItemPrice { get; set; } // optional
    }

}
