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



        public static PaymentHomeChefOrder ToEditModel(this AddPaymentHomeChefOrderVM addVM, PaymentHomeChefOrder old)
        {
            old.Amount = addVM.Amount > 0
                ? addVM.Amount
                : old.Amount;

            old.AmountPaid = addVM.AmountPaid > 0
                ? addVM.AmountPaid
                : old.AmountPaid;

            old.CommissionDeducted = addVM.CommissionDeducted; // bool, no validation

            old.CodeApplied = !string.IsNullOrWhiteSpace(addVM.CodeApplied)
                ? addVM.CodeApplied
                : old.CodeApplied;

            old.PaymentMethod = addVM.PaymentMethod; // enum, no validation

            old.PaymentStatus = addVM.PaymentStatus; // enum, no validation

            old.TransactionDateTime = addVM.TransactionDateTime != default(DateTime)
                ? addVM.TransactionDateTime
                : old.TransactionDateTime;

            old.HomeChefOrderId = addVM.HomeChefOrderId > 0
                ? addVM.HomeChefOrderId
                : old.HomeChefOrderId;

            return old;
        }

    }
}
