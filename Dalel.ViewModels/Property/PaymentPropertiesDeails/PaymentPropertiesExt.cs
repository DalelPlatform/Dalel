using Dalel.ViewModels.Property.PaymentPropertiesDeails;
using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class PaymentPropertiesExt
    {
        public static PaymentProperties ToModel(this AddPaymentPropertiesVM viewModel)
        {
            return new PaymentProperties
            {
                Amount = viewModel.Amount,
                PaymentMethod = viewModel.PaymentMethod,
                PaymentStatus = viewModel.PaymentStatus,
                TransactionDateTime = DateTime.Now,
                AmountPaid = viewModel.AmountPaid,
                CommissionDeducted = viewModel.CommissionDeducted,
                CodeApplied = viewModel.CodeApplied,
                BookingPropertyId = viewModel.BookingPropertyId
            };
        }

        public static PaymentPropertiesDetailsVM ToDetailsViewModel(this PaymentProperties paymentProperties)
        {
            return new PaymentPropertiesDetailsVM
            {
                Amount = paymentProperties.Amount,
                PaymentMethod = paymentProperties.PaymentMethod,
                PaymentStatus = paymentProperties.PaymentStatus,
                TransactionDateTime = paymentProperties.TransactionDateTime,
                AmountPaid = paymentProperties.AmountPaid,
                CommissionDeducted = paymentProperties.CommissionDeducted,
                CodeApplied = paymentProperties.CodeApplied
            };
        }
    }
}
