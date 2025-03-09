using Models.Property.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Models.Property
{
    public class PaymentProperties
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public PaymentType PaymentType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string ClientId { get; set; } // fk client.userid
        public int BookingPropertyId { get; set; } // fk BookingProperties.Id
    }
}
