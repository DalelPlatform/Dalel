using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.HomeChef.Enums
{
    public enum StatusOfDelivery
    {
        Pending,       // The order has been placed but not yet processed
        Processing,    // The order is being prepared
        Shipped,       // The order has been shipped
        OutForDelivery,// The order is on its way to the customer
        Delivered,     // The order has been delivered successfully
        Canceled,      // The order was canceled
        Returned       // The order was returned by the customer
    }

}
