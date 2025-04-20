namespace Utilities
{
    public class StripeService
    {
        public bool Charge(decimal amount, string orderId)
        {
            Console.WriteLine($"[Stripe] Charging {amount} for order {orderId}...");
            // Simulate success
            return true;
        }
    }
}