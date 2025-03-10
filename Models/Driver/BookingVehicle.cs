using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Driver
{
    public class BookingVehicle
    {
        public int Id { get; set; }

        
        public string PickupLocation { get; set; }

        
        public string DropoffLocation { get; set; }

        public decimal SuggestedPrice { get; set; }

        
        public int Status { get; set; }

        public int PassengersNo { get; set; }

        
        public DateTime StartedDateTime { get; set; }

        public DateTime EndedDateTime { get; set; }

        
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }

}
