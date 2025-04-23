using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class WalletService
    {
        public bool Charge(decimal amount, string orderId)
        {
            Console.WriteLine($"[Wallet] Charging {amount} for order {orderId}...");
            // Simulate success
            return true;
        }
    }
}
