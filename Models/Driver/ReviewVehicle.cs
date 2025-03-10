using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Driver
{
    public class ReviewVehicle
    {
        public int Id { get; set; }

        public string Comments { get; set; }

      
        public float Rating { get; set; }

        public DateTime ModificationDateTime { get; set; }

       
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

       
        public int BookingVehicleId { get; set; }
        public virtual BookingVehicle BookingVehicle { get; set; }
    }
}
