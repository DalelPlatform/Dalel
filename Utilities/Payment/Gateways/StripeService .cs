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
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(amount * 100), // cents
                    Currency = "usd",
                    Description = $"Charge for order {orderId}",
                    PaymentMethodTypes = new List<string> { "card" },
                };

                var service = new PaymentIntentService();
                var paymentIntent = service.Create(options);

                // Consider PaymentIntent successfully created if it's either 'requires_payment_method' or 'requires_confirmation'
                return paymentIntent != null && !string.IsNullOrEmpty(paymentIntent.Id);
            }
            catch (Exception ex)
            {
                // You can log the error
                return false;
            }
        }
    }
}
