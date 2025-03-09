using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Driver
{
    public class Vehicle
    {
        public int Id { get; set; }

       
        public string Type { get; set; }

        
        public string Model { get; set; }

        
        public string Color { get; set; }

        public int ModelYear { get; set; }

        public int Seats { get; set; }

        
        public string LicenseNumber { get; set; }

        
        public string PlateNumber { get; set; }

        
        public string OwnerId { get; set; }
        public virtual Driver Driver { get; set; }

        public virtual ICollection<VehicleImage> VehicleImages { get; set; }
    }
}
