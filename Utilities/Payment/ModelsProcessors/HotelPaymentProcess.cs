using Dalel.Repository;
using Models.Enums;
using Models.Hotel;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class HotelPaymentProcess : IPaymentProcessor<PaymentHotelRoom>
    {
        private readonly StripeService _stripeService;
        private readonly PayPalService _payPalService;
        private readonly PaymentHotelRoomRepository _paymentHotelRoomRepository;

        public HotelPaymentProcess(StripeService stripeService, PayPalService payPalService, 
            PaymentHotelRoomRepository paymentHotelRoomRepository)
        {
            _stripeService = stripeService;
            _payPalService = payPalService;
            _paymentHotelRoomRepository = paymentHotelRoomRepository;
        }

        public ServiceResult ProcessPayment(PaymentHotelRoom payment)
        {
            try
            {
                if (payment.AmountPaid <= 0)
                    return ServiceResult.FailureResult("Invalid payment amount.");

                // CodeApplied logic is needed
                //if (!string.IsNullOrEmpty(payment.CodeApplied))
                //    payment.AmountPaid = payment.AmountPaid * 0.9m;

                payment.CommissionDeducted = payment.AmountPaid * 0.15m;

                var orderId = payment.BookingHotelRoomId.ToString();
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

                _paymentHotelRoomRepository.Add(payment);

                return ServiceResult.SuccessResult("Hotel Room payment completed.");
            }
            catch (Exception ex)
            {
                return ServiceResult.FailureResult($"Payment failed: {ex.Message}");
            }
        }
    }
}
