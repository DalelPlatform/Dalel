namespace Utilities
{
    public class PayPalService
    {
        public bool Charge(decimal amount, string orderId)
        {
            Console.WriteLine($"[PayPal] Charging {amount} for order {orderId}...");
            // Simulate success
            return true;
        }
    }
}