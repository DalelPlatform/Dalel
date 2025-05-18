using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using System.Collections.Generic;
using System.Net;

namespace Utilities.Payments.Gateways
{
    public class PayPalService
    {
        private readonly IConfiguration _config;

        public PayPalService(IConfiguration config)
        {
            _config = config;
        }

        public bool Charge(decimal amount, string orderId)
        {
            var environment = new SandboxEnvironment(
                _config["PayPal:ClientId"],
                _config["PayPal:ClientSecret"]
            );

            var client = new PayPalHttpClient(environment);

            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(new OrderRequest
            {
                CheckoutPaymentIntent = "CAPTURE",
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest
                    {
                        ReferenceId = orderId,
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = "USD",
                            Value = amount.ToString("F2")
                        }
                    }
                }
            });

            try
            {
                var response = client.Execute(request).Result;
                return response.StatusCode == HttpStatusCode.Created;
            }
            catch
            {
                return false;
            }
        }
    }
}
