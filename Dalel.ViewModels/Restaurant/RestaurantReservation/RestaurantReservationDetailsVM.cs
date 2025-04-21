using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class RestaurantReservationDetailsVM
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        public string RestaurantName{ get; set; }
        public string? TableNumber { get; set; }
        public string ClientName { get; set; }

    }
}
