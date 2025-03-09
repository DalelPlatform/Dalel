using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Driver
{
    public class PaymentVehicle
    {
        public int Id { get; set; }

      
        public decimal Amount { get; set; }

       
        public int Type { get; set; }

       
        public int Status { get; set; }

        
        public DateTime TransactionDateTime { get; set; }

       
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        
        public int BookingVehicleId { get; set; }
        public virtual BookingVehicle BookingVehicle { get; set; }
    }
}
