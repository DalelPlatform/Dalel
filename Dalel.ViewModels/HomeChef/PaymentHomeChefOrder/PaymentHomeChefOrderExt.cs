using Dalel.ViewModels;
using Models.HomeChef;

namespace Dalel.ViewModels
{
    public static class PaymentHomeChefOrderExt
    {
        public static PaymentHomeChefOrder ToModel(this AddPaymentHomeChefOrderVM addPaymentHomeChefOrderVM)
        {
            return new PaymentHomeChefOrder
            {
                Amount = addPaymentHomeChefOrderVM.Amount,
                AmountPaid = addPaymentHomeChefOrderVM.AmountPaid,
                CommissionDeducted = addPaymentHomeChefOrderVM.CommissionDeducted,
                CodeApplied = addPaymentHomeChefOrderVM.CodeApplied,
                PaymentMethod = addPaymentHomeChefOrderVM.PaymentMethod,
                PaymentStatus = addPaymentHomeChefOrderVM.PaymentStatus,
                TransactionDateTime = addPaymentHomeChefOrderVM.TransactionDateTime,
                HomeChefOrderId = addPaymentHomeChefOrderVM.HomeChefOrderId
            };
        }

        public static PaymentHomeChefOrderDetailsVM ToDetailsViewModel(this PaymentHomeChefOrder paymentHomeChefOrder)
        {
            return new PaymentHomeChefOrderDetailsVM
            {
                Amount = paymentHomeChefOrder.Amount,
                AmountPaid = paymentHomeChefOrder.AmountPaid,
                CommissionDeducted = paymentHomeChefOrder.CommissionDeducted,
                CodeApplied = paymentHomeChefOrder.CodeApplied,
                PaymentMethod = paymentHomeChefOrder.PaymentMethod,
                PaymentStatus = paymentHomeChefOrder.PaymentStatus,
                TransactionDateTime = paymentHomeChefOrder.TransactionDateTime
            };
        }
    }
}
