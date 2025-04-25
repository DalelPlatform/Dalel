using Dalel.Reopsitory;
using Models.Driver;
using Models.Enums;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Payments.Gateways;

namespace Utilities
{
    public class DriverPaymentProcess : IPaymentProcessor<PaymentVehicle>
    {
        private readonly StripeService _stripeService;
        private readonly PayPalService _payPalService;
        private readonly PaymentVehicleRepository _paymentVehicleRepository;

        public DriverPaymentProcess(StripeService stripeService, PayPalService payPalService,
            PaymentVehicleRepository paymentVehicleRepository)
        {
            _stripeService = stripeService;
            _payPalService = payPalService;
            _paymentVehicleRepository = paymentVehicleRepository;
        }

        public ServiceResult ProcessPayment(PaymentVehicle payment)
        {
            try
            {
                if (payment.AmountPaid <= 0)
                    return ServiceResult.FailureResult("Invalid payment amount.");

                // CodeApplied logic is needed
                //if (!string.IsNullOrEmpty(payment.CodeApplied))
                //    payment.AmountPaid = payment.AmountPaid * 0.9m;

                payment.CommissionDeducted = payment.AmountPaid * 0.15m;

                var orderId = payment.BookingVehicleId.ToString();
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

                _paymentVehicleRepository.Add(payment);

                return ServiceResult.SuccessResult("Vehicle Booking payment completed.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Payment failed: {ex.Message}");
            }
        }
    }
}
