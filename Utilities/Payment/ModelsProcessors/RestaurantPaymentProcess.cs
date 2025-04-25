using Dalel.Repository;
using Models.Enums;
using Models.Restaurant;
using Utilities.Payments.Gateways;

namespace Utilities
{
    public class RestaurantPaymentProcess : IPaymentProcessor<PaymentRestaurantOrder>
    {
        private readonly StripeService _stripeService;
        private readonly PayPalService _payPalService;
        private readonly PaymentRestaurantOrderReopsitory _paymentRestaurantOrderRepository;

        public RestaurantPaymentProcess(StripeService stripeService, PayPalService payPalService, PaymentRestaurantOrderReopsitory paymentRestaurantOrderRepository)
        {
            _stripeService = stripeService;
            _payPalService = payPalService;
            _paymentRestaurantOrderRepository = paymentRestaurantOrderRepository;
        }

        public ServiceResult ProcessPayment(PaymentRestaurantOrder payment)
        {
            try
            {
                if (payment.AmountPaid <= 0)
                    return ServiceResult.FailureResult("Invalid payment amount.");

                // CodeApplied logic is needed
                //if (!string.IsNullOrEmpty(payment.CodeApplied))
                //    payment.AmountPaid = payment.AmountPaid * 0.9m;

                payment.CommissionDeducted = payment.AmountPaid * 0.15m;

                var orderId = payment.RestaurantOrderId.ToString();
                bool success = payment.PaymentType switch
                {
                    PaymentMethod.Stripe => _stripeService.Charge(payment.AmountPaid, orderId),
                    PaymentMethod.Paypal => _payPalService.Charge(payment.AmountPaid, orderId),
                    _ => true // Cash 
                };

                if (!success)
                    return ServiceResult.FailureResult("Payment gateway failed.");

                payment.TransactionDateTime = DateTime.Now;
                payment.PaymentStatus = PaymentStatus.Completed;

                _paymentRestaurantOrderRepository.Add(payment);

                return ServiceResult.SuccessResult("Restaurant Order payment completed.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Payment failed: {ex.Message}");
            }
        }
    }
}
