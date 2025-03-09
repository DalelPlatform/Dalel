using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Restaurant.Enums;

namespace Models.Restaurant
{
    public class PaymentRestaurantOrders
    {
        public int Id { get; set; }
        public float Amount { get; set; }   
        public TypeOfPayment PaymentType { get; set; }

        public StatusOfPaymentOrder PaymentOrderStatus { get; set; }

        public DateTime TransactionDateTime { get; set; }

        public string ClientId { get; set; } //fk

        public int RestaurantOrderId { get; set; } //fk
    }
}
