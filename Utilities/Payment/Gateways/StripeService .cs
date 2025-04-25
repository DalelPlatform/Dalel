using Microsoft.Extensions.Configuration;
using Stripe;

namespace Utilities
{
     public class StripeService
    {
        public StripeService(IConfiguration config)
        {
            StripeConfiguration.ApiKey = config["Stripe:SecretKey"];
        }

        public bool Charge(decimal amount, string orderId)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100), // in cents
                Currency = "usd",
                Description = $"Charge for order {orderId}",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);

            return paymentIntent.Status == "requires_payment_method" || paymentIntent.Status == "requires_confirmation";
        }
     } 
}