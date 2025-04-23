using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Payment.Gateways
{
    public class InstapayService
    {
        public bool Charge(decimal amount, string orderId)
        {
            Console.WriteLine($"[InstaPay] Charging {amount} for order {orderId}...");
            // Simulate success
            return true;
        }
    }
}
