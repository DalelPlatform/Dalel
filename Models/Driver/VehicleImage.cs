using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Driver
{
    public class VehicleImage
    {
        public int Id { get; set; }


        public string Image { get; set; }

        
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
