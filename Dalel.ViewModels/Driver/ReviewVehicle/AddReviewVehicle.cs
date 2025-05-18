using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddReviewVehicle
    {
        public string Comments { get; set; }
        public decimal Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public int BookingVehicleId { get; set; }
    }

}
