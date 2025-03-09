using Models.Property.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Models.Property
{
    public class BookingProperties
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public float Price { get; set; }
        public BookingStatus Status { get; set; } // int
        public int PropertyId { get; set; } // fk Properties
        public int ClientId { get; set; } // fk Clients.userid 
    }
}
