using Dalel.Repository.Agency;
using Models.Agency;
using Models.Enums;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Payments.Gateways;

namespace Utilities
{
    public class AgencyPaymentProcess : IPaymentProcessor<PackageBookingPayment>
    {
        private readonly StripeService _stripeService;
        private readonly PayPalService _payPalService;
        private readonly AgencyPaymentRepo _paymentPackageBookingRepository;

        public AgencyPaymentProcess(StripeService stripeService, PayPalService payPalService,
            AgencyPaymentRepo agencyPaymentRepo)
        {
            _stripeService = stripeService;
            _payPalService = payPalService;
            _paymentPackageBookingRepository = agencyPaymentRepo;
        }

        public ServiceResult ProcessPayment(PackageBookingPayment payment)
        {
            try
            {
                if (payment.AmountPaid <= 0)
                    return ServiceResult.FailureResult("Invalid payment amount.");

                // CodeApplied logic is needed
                //if (!string.IsNullOrEmpty(payment.CodeApplied))
                //    payment.AmountPaid = payment.AmountPaid * 0.9m;

                payment.CommissionDeducted = payment.AmountPaid * 0.15m;

                var orderId = payment.BookingId.ToString();
                bool success = payment.PaymentMethod switch
                {
                    PaymentMethod.Stripe => _stripeService.Charge(payment.AmountPaid, orderId),
                    PaymentMethod.Paypal => _payPalService.Charge(payment.AmountPaid, orderId),
                    _ => true // Cash 
                };

                if (!success)
                    return ServiceResult.FailureResult("Payment gateway failed.");

                payment.Date = DateTime.Now;
                payment.PaymentStatus = PaymentStatus.Completed;

                _paymentPackageBookingRepository.Add(payment);

                return ServiceResult.SuccessResult("Package Booking payment completed.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Payment failed: {ex.Message}");
            }
        }
    }
}
