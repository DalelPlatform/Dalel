using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddRestaurantCartItemVM
    {
        public float SupPrice { get; set; }
        public float Quantity { get; set; }

        
        public string? ClientId { get; set; } // optional, from  token

        public int RestaurantMenuItemId { get; set; }


    }

}
