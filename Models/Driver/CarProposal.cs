using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Driver
{
    public class CarProposal
    {
        public int Id { get; set; }

        
        public decimal Price { get; set; }

       
        public int Status { get; set; }

        public bool IsAccepted { get; set; }

        public decimal SuggestedPrice { get; set; }

       
        public DateTime StartedDateTime { get; set; }

        
        public string DriverId { get; set; }
        public virtual Driver Driver { get; set; }

        
        public int BookingVehicleId { get; set; }
        public virtual BookingVehicle BookingVehicle { get; set; }
    }
}
