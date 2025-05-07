using Dalel.Repository;
using Models.Enums;
using Models.HomeChef;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Payments.Gateways;

namespace Utilities
{
    public class HomeChefPaymentProcess : IPaymentProcessor<PaymentHomeChefOrder>
    {
        private readonly StripeService _stripeService;
        private readonly PayPalService _payPalService;
        private readonly PaymentHomeChefOrderRepasitory _paymentHomeChefOrderRepository;

        public HomeChefPaymentProcess(StripeService stripeService, PayPalService payPalService,
            PaymentHomeChefOrderRepasitory paymentHomeChefOrderRepasitory)
        {
            _stripeService = stripeService;
            _payPalService = payPalService;
            _paymentHomeChefOrderRepository = paymentHomeChefOrderRepasitory;
        }

        public ServiceResult ProcessPayment(PaymentHomeChefOrder payment)
        {
            try
            {
                if (payment.AmountPaid <= 0)
                    return ServiceResult.FailureResult("Invalid payment amount.");

                // CodeApplied logic is needed
                //if (!string.IsNullOrEmpty(payment.CodeApplied))
                //    payment.AmountPaid = payment.AmountPaid * 0.9m;

                payment.CommissionDeducted = payment.AmountPaid * 0.15m;

                var orderId = payment.HomeChefOrderId.ToString();
                bool success = payment.PaymentMethod switch
                {
                    PaymentMethod.Stripe => _stripeService.Charge(payment.AmountPaid, orderId),
                    PaymentMethod.Paypal => _payPalService.Charge(payment.AmountPaid, orderId),
                    _ => true // Cash 
                };

                if (!success)
                    return ServiceResult.FailureResult("Payment gateway failed.");

                payment.TransactionDateTime = DateTime.Now;
                payment.PaymentStatus = PaymentStatus.Completed;

                _paymentHomeChefOrderRepository.Add(payment);

                return ServiceResult.SuccessResult("HomeChef Order payment completed.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Payment failed: {ex.Message}");
            }
        }
    }
}
