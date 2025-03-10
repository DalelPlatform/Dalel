using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Property
{
    public class ReviewProperties
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public float Rating { get; set; }
        public DateTime ModificationDateTime { get; set; }
        public string ClientId { get; set; } // fk Client.UserId
        public int BookingPropertyId { get; set; } // fk BookingProperties.Id
    }
}
